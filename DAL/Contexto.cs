using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Registro3.Entidades;

namespace Registro3.DAL
{
    public class Contexto:DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public Contexto() : base("ConStr")
        {

        }
    }
}
