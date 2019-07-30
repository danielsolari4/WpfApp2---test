using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MisModelos
{
    public class Comanda
    {
        public int Id { get; set; }
        public int NumeroMesa { get; set; }
        public List<Producto> _lstProductos { get; set; }
        public string Comentario { get; set; }
    }

}
