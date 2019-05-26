using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Registro3.BLL;
using Registro3.DAL;
using Registro3.Entidades;
using System.Data.Entity;

namespace Registro3.UI.Consultas
{
    public partial class cCargos : Form
    {
        public cCargos()
        {
            InitializeComponent();

        }

        private void ConsultaButton_Click(object sender, EventArgs e)
        {
            var listado = new List<Cargos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://Todo
                        listado = CargosBLL.GetList(p => true);
                        break;

                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = CargosBLL.GetList(p => p.CargoId == id);
                        break;

                    case 2://Descripcion
                        listado = CargosBLL.GetList(p => p.Descripcion.Contains(CriterioTextBox.Text));
                        break;

                    
                }

                
            }
            else
            {
                listado = CargosBLL.GetList(p => true);
            }

            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = listado;
        }
    }
}
