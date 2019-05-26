using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Registro3.UI.Registros;
using Registro3.UI.Consultas;

namespace Registro3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void RegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rUsuarios registro = new rUsuarios();
            registro.Visible = true;
        }

        private void CargosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rCargos cargos = new rCargos();
            cargos.Visible = true;
        }

        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cUsuarios usuarios = new cUsuarios();
            usuarios.Visible = true;
        }

        private void CargosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cCargos cargos = new cCargos();
            cargos.Visible = true;
        }
    }
}
