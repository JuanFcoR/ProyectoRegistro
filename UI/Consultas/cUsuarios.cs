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
    public partial class cUsuarios : Form
    {
        public cUsuarios()
        {
            InitializeComponent();
        }

        private void ConsultaButton_Click(object sender, EventArgs e)
        {
            var listado = new List<Usuarios>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://Todo
                        listado = UsuariosBLL.GetList(p=>true);
                        break;

                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = UsuariosBLL.GetList(p => p.UsuarioId == id);
                        break;

                    case 2://Nombres
                        listado = UsuariosBLL.GetList(p => p.Nombres.Contains(CriterioTextBox.Text));
                        break;

                    case 3://Email
                        listado = UsuariosBLL.GetList(p => p.Email.Contains(CriterioTextBox.Text));
                        break;

                    case 4://NivelUsuario
                        listado = UsuariosBLL.GetList(p => p.NivelUsuario.Contains(CriterioTextBox.Text));
                        break;

                    case 5://Usuario
                        listado = UsuariosBLL.GetList(p => p.Usuario.Contains(CriterioTextBox.Text));
                        break;
                }

                listado = listado.Where(c => c.FechaIngreso.Date >= DesdeDateTimePicker.Value.Date && c.FechaIngreso.Date <= HastaDateTimePicker.Value.Date).ToList();
            }
            else
            {
                listado = UsuariosBLL.GetList(p => true);
            }

            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = listado;
        }
    }
}
