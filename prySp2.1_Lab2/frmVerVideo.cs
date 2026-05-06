using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prySp2._1_Lab2
{
    public partial class frmVerVideo : Form
    {
        public frmVerVideo()
        {
            InitializeComponent();
        }

        private void frmVerVideo_Load(object sender, EventArgs e)
        {
            LoadCantantes();
        }

        private void LoadCantantes()
        {
            var dt = DataStore.Cantantes;
            cmbCantante.DataSource = null;
            cmbCantante.DisplayMember = "Nombre";
            cmbCantante.ValueMember = DataStore.CantantesIdColumnName ?? "IdCantante";
            cmbCantante.DataSource = dt;
            cmbCantante.SelectedIndex = -1;
            cmbTema.DataSource = null;
        }

        private void cmbCantante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCantante.SelectedItem == null)
            {
                cmbTema.DataSource = null;
                return;
            }

            int idCant = Convert.ToInt32(((DataRowView)cmbCantante.SelectedItem)["IdCantante"]);
            var rows = DataStore.GetTemasByCantante(idCant);
            var dt = DataStore.Temas.Clone();
            foreach (var r in rows)
            {
                dt.ImportRow(r);
            }
            cmbTema.DataSource = dt;
            cmbTema.DisplayMember = "Nombre";
            cmbTema.ValueMember = "IdTema";
            if (dt.Rows.Count == 0) cmbTema.SelectedIndex = -1;
        }

        private void btnVerVideo_Click(object sender, EventArgs e)
        {
            if (cmbTema.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un tema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var url = Convert.ToString(((DataRowView)cmbTema.SelectedItem)["UrlVideo"]);
            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("La URL del video no está disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                webBrowserVideo.Navigate(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo navegar a la URL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void webBrowserVideo_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
