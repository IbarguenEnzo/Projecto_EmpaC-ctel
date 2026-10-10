using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empa.Datos.Entidades
{
    public class LogProducto
    {
        public int IdLog { get; set; }
        public string TablaAfectada { get; set; }
        public string UsuarioProceso { get; set; }
        public string Accion { get; set; } 
        public string Detalle { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
