using System;
using System.Data;
using Empa.Datos;

namespace Empa.Negocio
{
    public class CN_Productos
    {
        private readonly CD_Productos _objetoDatos = new CD_Productos();

        // 1. OBTENER LISTA DE PRODUCTOS
        public DataTable ObtenerProductos()
        {
            return _objetoDatos.ListarProductos();
        }

        // 2. OBTENER LISTA DE CATEGORÍAS (Para el ComboBox)
        public DataTable ObtenerCategorias()
        {
            return _objetoDatos.ListarCategorias();
        }

        // 3. REGISTRAR PRODUCTO (Validaciones IEEE 830)
        public bool RegistrarProducto(string nombre, string precioTexto, string stockTexto, object idCategoriaObj, out string mensajeError)
        {
            mensajeError = string.Empty;

            // Validar campos vacíos
            if (string.IsNullOrWhiteSpace(nombre))
            {
                mensajeError = "El nombre del producto no puede estar vacío.";
                return false;
            }

            // Validar conversión de Precio
            if (!int.TryParse(precioTexto, out int precio) || precio <= 0)
            {
                mensajeError = "El precio debe ser un número entero mayor a 0.";
                return false;
            }

            // Validar conversión de Stock
            if (!int.TryParse(stockTexto, out int stock) || stock < 0)
            {
                mensajeError = "El stock debe ser un número entero mayor o igual a 0.";
                return false;
            }

            // Validar selección de Categoría
            if (idCategoriaObj == null || !int.TryParse(idCategoriaObj.ToString(), out int idCategoria) || idCategoria <= 0)
            {
                mensajeError = "Debe seleccionar una categoría válida.";
                return false;
            }

            // Si todas las validaciones pasan, enviar a la Capa de Datos
            return _objetoDatos.InsertarProducto(nombre.Trim(), precio, stock, idCategoria);
        }

        // 4. MODIFICAR PRODUCTO
        public bool ModificarProducto(int idProducto, string nombre, string precioTexto, string stockTexto, object idCategoriaObj, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (idProducto <= 0)
            {
                mensajeError = "Debe seleccionar un producto válido para modificar.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(nombre))
            {
                mensajeError = "El nombre del producto no puede estar vacío.";
                return false;
            }

            if (!int.TryParse(precioTexto, out int precio) || precio <= 0)
            {
                mensajeError = "El precio debe ser un número entero mayor a 0.";
                return false;
            }

            if (!int.TryParse(stockTexto, out int stock) || stock < 0)
            {
                mensajeError = "El stock debe ser un número entero mayor o igual a 0.";
                return false;
            }

            if (idCategoriaObj == null || !int.TryParse(idCategoriaObj.ToString(), out int idCategoria) || idCategoria <= 0)
            {
                mensajeError = "Debe seleccionar una categoría válida.";
                return false;
            }

            return _objetoDatos.ActualizarProducto(idProducto, nombre.Trim(), precio, stock, idCategoria);
        }

        // 5. DESHABILITAR PRODUCTO (Borrado Lógico)
        public bool DeshabilitarProducto(int idProducto, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (idProducto <= 0)
            {
                mensajeError = "Debe seleccionar un producto válido para deshabilitar.";
                return false;
            }

            return _objetoDatos.EliminarLogico(idProducto);
        }

        // 6. OBTENER AUDITORÍA (ISO 27001)
        public DataTable ObtenerAuditoria()
        {
            return _objetoDatos.ListarAuditoria();
        }
    }
}