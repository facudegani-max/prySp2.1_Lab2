using System;
using System.Windows.Forms;

namespace prySp2._1_Lab2
{
    public class frmCantantes : Form
    {
        private Label lblNumero;
        private TextBox txtNumero;
        private Label lblNombre;
        private TextBox txtNombre;
        private Button btnAceptar;
        private Button btnCancelar;
        private Button btnSalir;

        public frmCantantes()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblNumero = new Label() { Text = "Número", Left = 10, Top = 20, Width = 80 };
            this.txtNumero = new TextBox() { Left = 100, Top = 18, Width = 150, Name = "txtNumero" };
            this.lblNombre = new Label() { Text = "Nombre", Left = 10, Top = 60, Width = 80 };
            this.txtNombre = new TextBox() { Left = 100, Top = 58, Width = 250, Name = "txtNombre" };

            this.btnAceptar = new Button() { Text = "Aceptar", Left = 40, Top = 110, Width = 80 };
            this.btnCancelar = new Button() { Text = "Cancelar", Left = 140, Top = 110, Width = 80 };
            this.btnSalir = new Button() { Text = "Salir", Left = 240, Top = 110, Width = 80 };

            this.btnAceptar.Click += BtnAceptar_Click;
            this.btnCancelar.Click += BtnCancelar_Click;
            this.btnSalir.Click += BtnSalir_Click;

            this.Controls.AddRange(new Control[] { lblNumero, txtNumero, lblNombre, txtNombre, btnAceptar, btnCancelar, btnSalir });
            this.Text = "Nuevo Cantante";
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new System.Drawing.Size(380, 160);
        }

        private void BtnSalir_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCancelar_Click(object? sender, EventArgs e)
        {
            txtNumero.Text = string.Empty;
            txtNombre.Text = string.Empty;
        }

        private void BtnAceptar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumero.Text))
            {
                MessageBox.Show("El número no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txtNumero.Text.Trim(), out int numero))
            {
                MessageBox.Show("El número debe ser un entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DataStore.CantanteNumeroExists(numero))
            {
                MessageBox.Show("Ya existe un cantante con ese número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataStore.AddCantante(numero, txtNombre.Text.Trim());
            MessageBox.Show("Cantante agregado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNumero.Text = string.Empty;
            txtNombre.Text = string.Empty;
        }
    }
}
