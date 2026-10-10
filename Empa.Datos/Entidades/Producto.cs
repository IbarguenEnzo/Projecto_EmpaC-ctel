using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empa.Datos.Entidades
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProd { get; set; }
        public int Precio { get; set; }
        public int StockDisponible { get; set; }
        public int IdCategoria { get; set; }
        public bool Estado { get; set; }

        // Propiedad auxiliar: nos servirá para mostrar el nombre legible de la categoría en el DataGridView
        public string NombreCategoria { get; set; }
    }
}
