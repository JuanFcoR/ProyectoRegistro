using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registro3.BLL;
using System.Data.Entity;
using System.Linq.Expressions;
using Registro3.Entidades;
using Registro3.DAL;

namespace Registro3.BLL
{
    public class CargosBLL
    {
        public static bool Guardar(Cargos cargos)
        {
            bool paso = false;
            ContextCargo contextoCargo = new ContextCargo();
            try
            {
                if(contextoCargo.Cargos.Add(cargos)!=null)
                {
                    contextoCargo.SaveChanges();
                    paso = true;
                }
                contextoCargo.Dispose();
            }
            catch(Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Editar(Cargos cargos)
        {
            ContextCargo contextoCargo = new ContextCargo();
            bool paso = false;
            try
            {
                contextoCargo.Entry(cargos).State = EntityState.Modified;
                if(contextoCargo.SaveChanges()>0)
                {
                    paso = true;
                }
                contextoCargo.Dispose();
            }
            catch(Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            ContextCargo contextoCargo = new ContextCargo();
            try
            {
                Cargos cargos = contextoCargo.Cargos.Find(id);
                contextoCargo.Cargos.Remove(cargos);

                paso = contextoCargo.SaveChanges() > 0;
                contextoCargo.Dispose();
            }

            catch (Exception)
            {

                throw;
            }
            
            return paso;
        }

        public static Cargos Buscar(int id)
        {
            ContextCargo contextoCargo = new ContextCargo();
            Cargos cargos = new Cargos();

            try
            {
                cargos=contextoCargo.Cargos.Find(id);
                contextoCargo.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
           

            return cargos;
        }


    }
}
