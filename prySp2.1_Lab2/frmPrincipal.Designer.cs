using System;
using System.Windows.Forms;

namespace prySp2._1_Lab2
{
    partial class frmPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuCantantes;
        private ToolStripMenuItem menuTemas;
        private ToolStripMenuItem miNuevoCantante;
        private ToolStripMenuItem miSalir;
        private ToolStripMenuItem miNuevoTema;
        private ToolStripMenuItem miVerVideoTema;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            menuStrip1 = new MenuStrip();
            menuCantantes = new ToolStripMenuItem();
            miNuevoCantante = new ToolStripMenuItem();
            miSalir = new ToolStripMenuItem();
            menuTemas = new ToolStripMenuItem();
            miNuevoTema = new ToolStripMenuItem();
            miVerVideoTema = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuCantantes, menuTemas });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(584, 24);
            menuStrip1.TabIndex = 0;
            // 
            // menuCantantes
            // 
            menuCantantes.DropDownItems.AddRange(new ToolStripItem[] { miNuevoCantante, miSalir });
            menuCantantes.Name = "menuCantantes";
            menuCantantes.Size = new Size(72, 20);
            menuCantantes.Text = "Cantantes";
            // 
            // miNuevoCantante
            // 
            miNuevoCantante.Name = "miNuevoCantante";
            miNuevoCantante.Size = new Size(160, 22);
            miNuevoCantante.Text = "Nuevo Cantante";
            miNuevoCantante.Click += MiNuevoCantante_Click;
            // 
            // miSalir
            // 
            miSalir.Name = "miSalir";
            miSalir.Size = new Size(160, 22);
            miSalir.Text = "Salir";
            miSalir.Click += MiSalir_Click;
            // 
            // menuTemas
            // 
            menuTemas.DropDownItems.AddRange(new ToolStripItem[] { miNuevoTema, miVerVideoTema });
            menuTemas.Name = "menuTemas";
            menuTemas.Size = new Size(53, 20);
            menuTemas.Text = "Temas";
            // 
            // miNuevoTema
            // 
            miNuevoTema.Name = "miNuevoTema";
            miNuevoTema.Size = new Size(155, 22);
            miNuevoTema.Text = "Nuevo Tema";
            miNuevoTema.Click += MiNuevoTema_Click;
            // 
            // miVerVideoTema
            // 
            miVerVideoTema.Name = "miVerVideoTema";
            miVerVideoTema.Size = new Size(155, 22);
            miVerVideoTema.Text = "Ver Video Tema";
            miVerVideoTema.Click += MiVerVideoTema_Click;
            // 
            // frmPrincipal
            // 
            ClientSize = new Size(584, 361);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "frmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Academia de Música";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
