using System;
using System;
using System.Windows.Forms;

namespace prySp2._1_Lab2
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void MiVerVideoTema_Click(object? sender, EventArgs e)
        {
            using var f = new frmVerVideo();
            f.ShowDialog();
        }

        private void MiNuevoTema_Click(object? sender, EventArgs e)
        {
            using var f = new frmTemas();
            f.ShowDialog();
        }

        private void MiSalir_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MiNuevoCantante_Click(object? sender, EventArgs e)
        {
            using var f = new frmCantantes();
            f.ShowDialog();
        }
    }
}
