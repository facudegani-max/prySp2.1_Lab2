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
    public partial class frmTemas : Form
    {
        public frmTemas()
        {
            InitializeComponent();
        }

        private void frmTemas_Load(object sender, EventArgs e)
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
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumero.Text))
            {
                MessageBox.Show("El número del tema no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtNumero.Text.Trim(), out int numero))
            {
                MessageBox.Show("El número debe ser un entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del tema no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUrlVideo.Text))
            {
                MessageBox.Show("La URL del video no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbCantante.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un cantante.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DataStore.TemaNumeroExists(numero))
            {
                MessageBox.Show("Ya existe un tema con ese número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idCant = Convert.ToInt32(((DataRowView)cmbCantante.SelectedItem)["IdCantante"]);
            DataStore.AddTema(numero, txtNombre.Text.Trim(), txtUrlVideo.Text.Trim(), idCant);
            MessageBox.Show("Tema agregado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNumero.Clear();
            txtNombre.Clear();
            txtUrlVideo.Clear();
            if (cmbCantante.Items.Count > 0) cmbCantante.SelectedIndex = -1;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
