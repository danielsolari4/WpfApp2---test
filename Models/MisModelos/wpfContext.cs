using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MisModelos
{
    public class wpfContext : DbContext
    {
        public wpfContext() : base("connectionWpf")
        {

        }

        public DbSet<Producto> ProductosTablita { get; set; }
        public DbSet<Producto> ComandaTablita { get; set; }
        public DbSet<Producto> ListaComandaTablita { get; set; }

    }
}
