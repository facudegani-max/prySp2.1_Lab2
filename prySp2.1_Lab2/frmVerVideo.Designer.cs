namespace prySp2._1_Lab2
{
    partial class frmVerVideo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVerVideo));
            label1 = new Label();
            cmbCantante = new ComboBox();
            label2 = new Label();
            cmbTema = new ComboBox();
            btnVerVideo = new Button();
            btnSalir = new Button();
            webBrowserVideo = new WebBrowser();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 0;
            label1.Text = "Cantante";
            // 
            // cmbCantante
            // 
            cmbCantante.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCantante.FormattingEnabled = true;
            cmbCantante.Location = new Point(80, 12);
            cmbCantante.Name = "cmbCantante";
            cmbCantante.Size = new Size(250, 23);
            cmbCantante.TabIndex = 1;
            cmbCantante.SelectedIndexChanged += cmbCantante_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(350, 15);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 2;
            label2.Text = "Tema";
            // 
            // cmbTema
            // 
            cmbTema.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTema.FormattingEnabled = true;
            cmbTema.Location = new Point(400, 12);
            cmbTema.Name = "cmbTema";
            cmbTema.Size = new Size(300, 23);
            cmbTema.TabIndex = 3;
            // 
            // btnVerVideo
            // 
            btnVerVideo.Location = new Point(720, 12);
            btnVerVideo.Name = "btnVerVideo";
            btnVerVideo.Size = new Size(75, 23);
            btnVerVideo.TabIndex = 4;
            btnVerVideo.Text = "Ver Video";
            btnVerVideo.UseVisualStyleBackColor = true;
            btnVerVideo.Click += btnVerVideo_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(720, 45);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // webBrowserVideo
            // 
            webBrowserVideo.Location = new Point(12, 80);
            webBrowserVideo.MinimumSize = new Size(20, 20);
            webBrowserVideo.Name = "webBrowserVideo";
            webBrowserVideo.Size = new Size(783, 360);
            webBrowserVideo.TabIndex = 6;
            webBrowserVideo.DocumentCompleted += webBrowserVideo_DocumentCompleted;
            // 
            // frmVerVideo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 455);
            Controls.Add(label1);
            Controls.Add(cmbCantante);
            Controls.Add(label2);
            Controls.Add(cmbTema);
            Controls.Add(btnVerVideo);
            Controls.Add(btnSalir);
            Controls.Add(webBrowserVideo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmVerVideo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ver Video";
            Load += frmVerVideo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCantante;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTema;
        private System.Windows.Forms.Button btnVerVideo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.WebBrowser webBrowserVideo;

        #endregion
    }
}