using System;
using System.Windows.Forms;

namespace prySp2._1_Lab2
{
    public class frmPrincipal : Form
    {
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuCantantes;
        private ToolStripMenuItem menuTemas;
        private ToolStripMenuItem miNuevoCantante;
        private ToolStripMenuItem miSalir;
        private ToolStripMenuItem miNuevoTema;
        private ToolStripMenuItem miVerVideoTema;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new MenuStrip();
            this.menuCantantes = new ToolStripMenuItem("Cantantes");
            this.menuTemas = new ToolStripMenuItem("Temas");
            this.miNuevoCantante = new ToolStripMenuItem("Nuevo Cantante");
            this.miSalir = new ToolStripMenuItem("Salir");
            this.miNuevoTema = new ToolStripMenuItem("Nuevo Tema");
            this.miVerVideoTema = new ToolStripMenuItem("Ver Video Tema");

            this.menuStrip1.Items.AddRange(new ToolStripItem[] { this.menuCantantes, this.menuTemas });
            this.menuCantantes.DropDownItems.AddRange(new ToolStripItem[] { this.miNuevoCantante, this.miSalir });
            this.menuTemas.DropDownItems.AddRange(new ToolStripItem[] { this.miNuevoTema, this.miVerVideoTema });

            this.miNuevoCantante.Click += MiNuevoCantante_Click;
            this.miSalir.Click += MiSalir_Click;
            this.miNuevoTema.Click += MiNuevoTema_Click;
            this.miVerVideoTema.Click += MiVerVideoTema_Click;

            this.MainMenuStrip = this.menuStrip1;
            this.Controls.Add(this.menuStrip1);
            this.Text = "Academia de Música";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 600;
            this.Height = 400;
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
