USE master;
GO

-- 1. Crear únicamente la nueva BD "EmpaCoctel" si no existe
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'EmpaCoctel')
BEGIN
    CREATE DATABASE EmpaCoctel;
END
GO

-- 2. Cambiar de contexto de forma estricta a EmpaCoctel
USE EmpaCoctel;
GO

-- ============================================================================
-- TABLAS DEL MVP
-- ============================================================================
CREATE TABLE CATEGORIAS (
    IdCategoria INT IDENTITY(1,1) PRIMARY KEY, 
    NombreCat VARCHAR(50) NOT NULL,
    Estado BIT NOT NULL DEFAULT 1
);
GO

INSERT INTO CATEGORIAS (NombreCat) 
VALUES ('Empanadas Tradicionales'), 
       ('Empanadas de Mariscos'), 
       ('Empanadas Vegetarianas/Especiales');
GO

CREATE TABLE PRODUCTOS (
    IdProducto INT IDENTITY(1,1) PRIMARY KEY, 
    NombreProd VARCHAR(100) NOT NULL,
    Precio INT NOT NULL,
    StockDisponible INT NOT NULL DEFAULT 0,
    IdCategoria INT NOT NULL,
    Estado BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_Producto_Categoria FOREIGN KEY (IdCategoria) REFERENCES CATEGORIAS(IdCategoria)
);
GO

INSERT INTO PRODUCTOS (NombreProd, Precio, StockDisponible, IdCategoria)
VALUES ('Empanada Cóctel Pino Horno (Ciento)', 25000, 500, 1),
       ('Empanada Cóctel Queso Frita (Ciento)', 22000, 800, 1),
       ('Empanada Cóctel Camarón Queso (Ciento)', 30000, 300, 2),
       ('Empanada Cóctel Espinaca Crema (Ciento)', 23000, 200, 3);
GO

CREATE TABLE LOG_PRODUCTOS (
    IdLog INT IDENTITY(1,1) PRIMARY KEY,
    TablaAfectada VARCHAR(50) NOT NULL DEFAULT 'PRODUCTOS',
    UsuarioProceso VARCHAR(100) NOT NULL DEFAULT SUSER_SNAME(),
    Accion VARCHAR(20) NOT NULL,
    Detalle VARCHAR(MAX) NOT NULL,
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE()
);
GO

-- ============================================================================
-- TRIGGER
-- ============================================================================
CREATE TRIGGER tr_AuditoriaProd
ON PRODUCTOS 
AFTER INSERT, UPDATE, DELETE 
AS 
BEGIN
    SET NOCOUNT ON;
    DECLARE @Usuario VARCHAR(100) = SUSER_SNAME();

    IF EXISTS(SELECT 1 FROM inserted WHERE Precio <= 0)
    BEGIN
        RAISERROR('[ERROR REGLA NEGOCIO] El precio de una empanada debe ser mayor a $0.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM inserted) AND NOT EXISTS (SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO LOG_PRODUCTOS (TablaAfectada, UsuarioProceso, Accion, Detalle)
        SELECT 
            'PRODUCTOS', @Usuario, 'INSERT', 
            CONCAT('Producto creado: "', NombreProd, '" (ID: ', IdProducto, ') | Stock Inicial: ', StockDisponible, ' | Precio: $', Precio)
        FROM inserted;
    END

    IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
    BEGIN
        IF EXISTS (SELECT 1 FROM inserted i JOIN deleted d ON i.IdProducto = d.IdProducto WHERE i.Estado = 0 AND d.Estado = 1)
        BEGIN
            INSERT INTO LOG_PRODUCTOS (TablaAfectada, UsuarioProceso, Accion, Detalle)
            SELECT 
                'PRODUCTOS', @Usuario, 'DELETE', 
                CONCAT('Producto deshabilitado (Borrado Lógico) - ID: ', IdProducto, ' | Nombre: "', NombreProd, '"')
            FROM inserted;
        END
        ELSE
        BEGIN
            INSERT INTO LOG_PRODUCTOS (TablaAfectada, UsuarioProceso, Accion, Detalle)
            SELECT 
                'PRODUCTOS', @Usuario, 'UPDATE', 
                CONCAT('Producto modificado (ID: ', i.IdProducto, ') | Nombre: "', d.NombreProd, '" -> "', i.NombreProd, '" | Stock: ', d.StockDisponible, ' -> ', i.StockDisponible, ' | Precio: $', d.Precio, ' -> $', i.Precio)
            FROM inserted i JOIN deleted d ON i.IdProducto = d.IdProducto;
        END
    END
    
    IF NOT EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO LOG_PRODUCTOS (TablaAfectada, UsuarioProceso, Accion, Detalle)
        SELECT 
            'PRODUCTOS', @Usuario, 'DELETE_FISICO', 
            CONCAT('ADVERTENCIA: Producto eliminado físicamente de la BD - ID: ', IdProducto, ' | Nombre: "', NombreProd, '"')
        FROM deleted;
    END
END;
GO

-- ============================================================================
-- PROCEDIMIENTOS ALMACENADOS
-- ============================================================================
CREATE PROCEDURE sp_Categorias_Consultar
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdCategoria, NombreCat FROM CATEGORIAS WHERE Estado = 1 ORDER BY NombreCat ASC;
END;
GO

CREATE PROCEDURE sp_Productos_Consultar
AS
BEGIN
    SET NOCOUNT ON;
    SELECT p.IdProducto, p.NombreProd, p.Precio, p.StockDisponible, p.IdCategoria, c.NombreCat AS NombreCategoria
    FROM PRODUCTOS p
    INNER JOIN CATEGORIAS c ON p.IdCategoria = c.IdCategoria
    WHERE p.Estado = 1
    ORDER BY p.IdProducto DESC;
END;
GO

CREATE PROCEDURE sp_Productos_Insertar
    @NombreProd VARCHAR(100),
    @Precio INT,
    @StockDisponible INT,
    @IdCategoria INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO PRODUCTOS (NombreProd, Precio, StockDisponible, IdCategoria)
    VALUES (@NombreProd, @Precio, @StockDisponible, @IdCategoria);
END;
GO

CREATE PROCEDURE sp_Productos_Actualizar
    @IdProducto INT,
    @NombreProd VARCHAR(100),
    @Precio INT,
    @StockDisponible INT,
    @IdCategoria INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE PRODUCTOS
    SET NombreProd = @NombreProd, Precio = @Precio, StockDisponible = @StockDisponible, IdCategoria = @IdCategoria
    WHERE IdProducto = @IdProducto AND Estado = 1;
END;
GO

CREATE PROCEDURE sp_Productos_EliminarLogico
    @IdProducto INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE PRODUCTOS SET Estado = 0 WHERE IdProducto = @IdProducto;
END;
GO

CREATE PROCEDURE sp_Auditoria_Consultar
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdLog, UsuarioProceso, Accion, Detalle, FechaRegistro FROM LOG_PRODUCTOS ORDER BY IdLog DESC;
END;
GO