using System;
using System.Data;
using System.Data.SqlClient;

namespace Empa.Datos
{
    public class CD_Productos
    {
        private readonly Conexion _conexion = new Conexion();

        
        public DataTable ListarProductos()
        {
            DataTable tabla = new DataTable();
            using (SqlConnection con = _conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_Productos_Consultar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader leer = cmd.ExecuteReader();
                    tabla.Load(leer);
                }
            }
            return tabla;
        }

         
        public DataTable ListarCategorias()
        {
            DataTable tabla = new DataTable();
            using (SqlConnection con = _conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_Categorias_Consultar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader leer = cmd.ExecuteReader();
                    tabla.Load(leer);
                }
            }
            return tabla;
        }

        
        public bool InsertarProducto(string nombre, int precio, int stock, int idCategoria)
        {
            using (SqlConnection con = _conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_Productos_Insertar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreProd", nombre);
                    cmd.Parameters.AddWithValue("@Precio", precio);
                    cmd.Parameters.AddWithValue("@StockDisponible", stock);
                    cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);

                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        
        public bool ActualizarProducto(int idProducto, string nombre, int precio, int stock, int idCategoria)
        {
            using (SqlConnection con = _conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_Productos_Actualizar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                    cmd.Parameters.AddWithValue("@NombreProd", nombre);
                    cmd.Parameters.AddWithValue("@Precio", precio);
                    cmd.Parameters.AddWithValue("@StockDisponible", stock);
                    cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);

                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        
        public bool EliminarLogico(int idProducto)
        {
            using (SqlConnection con = _conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_Productos_EliminarLogico", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // 6. CONSULTAR HISTORIAL DE AUDITORÍA (ISO 27001)
        public DataTable ListarAuditoria()
        {
            DataTable tabla = new DataTable();
            using (SqlConnection con = _conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_Auditoria_Consultar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader leer = cmd.ExecuteReader();
                    tabla.Load(leer);
                }
            }
            return tabla;
        }
    }
}