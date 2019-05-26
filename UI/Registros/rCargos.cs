using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using Registro3.BLL;
using Registro3.DAL;
using Registro3.Entidades;

namespace Registro3.UI.Registros
{
    public partial class rCargos : Form
    {
        public rCargos()
        {
            InitializeComponent();
        }

        private void limpiar()
        {
            CargoIdNumericUpDown.Value = 0;
            DescripcionTextBox.Text = String.Empty;
            SuperErrorProvider.Clear();
        }

        private bool Validar()
        {
            bool paso = true;
            SuperErrorProvider.Clear();
           

                if (String.IsNullOrWhiteSpace(DescripcionTextBox.Text))
                {
                    SuperErrorProvider.SetError(DescripcionTextBox, "Este campo no debe estar vacio");
                    DescripcionTextBox.Focus();
                    paso = false;
                }
            
            return paso;
        }

        private Cargos llenarClase()
        {
            Cargos Cargo = new Cargos();
            Cargo.CargoId = Convert.ToInt32(CargoIdNumericUpDown.Value);
            Cargo.Descripcion = DescripcionTextBox.Text.ToString();
            return Cargo;
        }

        private void LlenarCampos(Cargos Cargo)
        {
            CargoIdNumericUpDown.Value = Cargo.CargoId;
            DescripcionTextBox.Text = Cargo.Descripcion;
        }

        private bool ExisteEnLaBasedeDatos()
        {
            Cargos Cargo = CargosBLL.Buscar((int)CargoIdNumericUpDown.Value);
            return (Cargo != null);
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Cargos Cargo = new Cargos();
            int.TryParse(CargoIdNumericUpDown.Value.ToString(), out id);
            limpiar();

            Cargo= CargosBLL.Buscar(id);

            if (Cargo != null)
            {
                MessageBox.Show("Cargo Encontrado");
                LlenarCampos(Cargo);
            }
            else
                MessageBox.Show("Cargo no encontrado");
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Cargos Cargo;
            bool paso = false;


            if (!Validar())
                return;
            Cargo = llenarClase();
            limpiar();

            if (CargoIdNumericUpDown.Value == 0)
            {
                paso = CargosBLL.Guardar(Cargo);
            }
            else
            {
                if (!ExisteEnLaBasedeDatos())
                {
                    MessageBox.Show("No se puede modificar un cargo que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = CargosBLL.Editar(Cargo);
            }
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
                MessageBox.Show("No se pudo guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {

            SuperErrorProvider.Clear();
            int id;
            int.TryParse(Convert.ToString(CargoIdNumericUpDown.Value), out id);
            limpiar();
            if (CargosBLL.Eliminar(id))
                MessageBox.Show("Eliminado");
            else
                SuperErrorProvider.SetError(CargoIdNumericUpDown, "No se puede eliminar un cargo que no existe");
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}
