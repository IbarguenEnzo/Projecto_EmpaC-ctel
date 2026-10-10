using System.Data.SqlClient;

namespace Empa.Datos
{
    public class Conexion
    {
        // Conexión directa a la instancia de tu SQL Server y a la nueva BD
        private readonly string _cadenaConexion = @"Server=ENZO\SQLEXPRESS; Database=EmpaCoctel; Integrated Security=True;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_cadenaConexion);
        }
    }
}
