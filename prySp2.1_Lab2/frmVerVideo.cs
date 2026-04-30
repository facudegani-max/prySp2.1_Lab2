using System;
using System.Data;
using System.Windows.Forms;

namespace prySp2._1_Lab2
{
    public class frmVerVideo : Form
    {
        private Label lblCantante;
        private ComboBox cmbCantante;
        private Label lblTema;
        private ComboBox cmbTema;
        private Button btnVerVideo;
        private Button btnSalir;
        private WebBrowser webBrowserVideo;

        public frmVerVideo()
        {
            InitializeComponent();
            LoadCantantes();
        }

        private void InitializeComponent()
        {
            this.lblCantante = new Label() { Text = "Cantante", Left = 10, Top = 10, Width = 80 };
            this.cmbCantante = new ComboBox() { Left = 100, Top = 8, Width = 300, DropDownStyle = ComboBoxStyle.DropDownList };
            this.lblTema = new Label() { Text = "Tema", Left = 10, Top = 50, Width = 80 };
            this.cmbTema = new ComboBox() { Left = 100, Top = 48, Width = 300, DropDownStyle = ComboBoxStyle.DropDownList };
            this.btnVerVideo = new Button() { Text = "Ver Video", Left = 420, Top = 8, Width = 90 };
            this.btnSalir = new Button() { Text = "Salir", Left = 420, Top = 48, Width = 90 };
            this.webBrowserVideo = new WebBrowser() { Left = 10, Top = 90, Width = 760, Height = 360 };

            this.cmbCantante.SelectedIndexChanged += CmbCantante_SelectedIndexChanged;
            this.btnVerVideo.Click += BtnVerVideo_Click;
            this.btnSalir.Click += BtnSalir_Click;

            this.Controls.AddRange(new Control[] { lblCantante, cmbCantante, lblTema, cmbTema, btnVerVideo, btnSalir, webBrowserVideo });
            this.Text = "Ver Video Tema";
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new System.Drawing.Size(780, 470);
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

        private void CmbCantante_SelectedIndexChanged(object? sender, EventArgs e)
        {
            cmbTema.DataSource = null;
            if (cmbCantante.SelectedItem == null) return;
            var id = Convert.ToInt32(((DataRowView)cmbCantante.SelectedItem)["IdCantante"]);
            var rows = DataStore.GetTemasByCantante(id);
            if (rows.Length > 0)
            {
                var table = rows.CopyToDataTable();
                cmbTema.DataSource = table;
                cmbTema.DisplayMember = "Nombre";
                cmbTema.ValueMember = "IdTema";
                cmbTema.SelectedIndex = -1;
            }
        }

        private void BtnVerVideo_Click(object? sender, EventArgs e)
        {
            if (cmbTema.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un tema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var url = ((DataRowView)cmbTema.SelectedItem)["UrlVideo"].ToString();
            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("La URL del tema está vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                webBrowserVideo.Navigate(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se puede navegar a la URL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSalir_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
