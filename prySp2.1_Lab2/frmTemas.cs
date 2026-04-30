using System;
using System.Data;
using System.Windows.Forms;

namespace prySp2._1_Lab2
{
    public class frmTemas : Form
    {
        private Label lblNumero;
        private TextBox txtNumero;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblUrl;
        private TextBox txtUrlVideo;
        private Label lblCantante;
        private ComboBox cmbCantante;
        private Button btnAceptar;
        private Button btnCancelar;
        private Button btnSalir;

        public frmTemas()
        {
            InitializeComponent();
            LoadCantantes();
        }

        private void InitializeComponent()
        {
            this.lblNumero = new Label() { Text = "Número", Left = 10, Top = 20, Width = 80 };
            this.txtNumero = new TextBox() { Left = 100, Top = 18, Width = 150 };
            this.lblNombre = new Label() { Text = "Nombre", Left = 10, Top = 60, Width = 80 };
            this.txtNombre = new TextBox() { Left = 100, Top = 58, Width = 250 };
            this.lblUrl = new Label() { Text = "Dirección Web", Left = 10, Top = 100, Width = 80 };
            this.txtUrlVideo = new TextBox() { Left = 100, Top = 98, Width = 250 };
            this.lblCantante = new Label() { Text = "Cantante", Left = 10, Top = 140, Width = 80 };
            this.cmbCantante = new ComboBox() { Left = 100, Top = 138, Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };

            this.btnAceptar = new Button() { Text = "Aceptar", Left = 40, Top = 190, Width = 80 };
            this.btnCancelar = new Button() { Text = "Cancelar", Left = 140, Top = 190, Width = 80 };
            this.btnSalir = new Button() { Text = "Salir", Left = 240, Top = 190, Width = 80 };

            this.btnAceptar.Click += BtnAceptar_Click;
            this.btnCancelar.Click += BtnCancelar_Click;
            this.btnSalir.Click += BtnSalir_Click;

            this.Controls.AddRange(new Control[] { lblNumero, txtNumero, lblNombre, txtNombre, lblUrl, txtUrlVideo, lblCantante, cmbCantante, btnAceptar, btnCancelar, btnSalir });
            this.Text = "Nuevo Tema";
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new System.Drawing.Size(380, 240);
        }

        private void LoadCantantes()
        {
            cmbCantante.DataSource = null;
            if (DataStore.Cantantes.Rows.Count > 0)
            {
                cmbCantante.DataSource = DataStore.Cantantes;
                cmbCantante.DisplayMember = "Nombre";
                cmbCantante.ValueMember = "IdCantante";
                cmbCantante.SelectedIndex = -1;
            }
        }

        private void BtnSalir_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCancelar_Click(object? sender, EventArgs e)
        {
            txtNumero.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtUrlVideo.Text = string.Empty;
            cmbCantante.SelectedIndex = -1;
        }

        private void BtnAceptar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumero.Text))
            {
                MessageBox.Show("El número del tema no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txtNumero.Text.Trim(), out int numero))
            {
                MessageBox.Show("El número del tema debe ser un entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            var idCantante = Convert.ToInt32(((DataRowView)cmbCantante.SelectedItem)["IdCantante"]);
            DataStore.AddTema(numero, txtNombre.Text.Trim(), txtUrlVideo.Text.Trim(), idCantante);
            MessageBox.Show("Tema agregado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNumero.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtUrlVideo.Text = string.Empty;
            cmbCantante.SelectedIndex = -1;
        }
    }
}
