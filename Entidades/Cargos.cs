using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Registro3.Entidades
{
   public class Cargos
    {
        public int CargoId { get; set; }
        public string Descripcion { get; set; }


        public Cargos()
        {
            CargoId = 0;
            Descripcion = String.Empty;
        }
    }
}
