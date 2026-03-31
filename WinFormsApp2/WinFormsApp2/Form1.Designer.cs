namespace WinFormsApp2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnGrupo1;
        private System.Windows.Forms.Button btnGrupo2;
        private System.Windows.Forms.Button btnGrupo3;
        private System.Windows.Forms.Button btnOpcionales;
        private System.Windows.Forms.Label lblTitulo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblTitulo = new System.Windows.Forms.Label();
            btnGrupo1 = new System.Windows.Forms.Button();
            btnGrupo2 = new System.Windows.Forms.Button();
            btnGrupo3 = new System.Windows.Forms.Button();
            btnOpcionales = new System.Windows.Forms.Button();

            // lblTitulo
            lblTitulo.AutoSize = false;
            lblTitulo.Location = new Point(50, 30);
            lblTitulo.Size = new Size(400, 50);
            lblTitulo.Text = "MENÚ DE";
            lblTitulo.Font = new Font("Arial", 28, FontStyle.Bold);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // btnGrupo1
            btnGrupo1.Location = new Point(100, 120);
            btnGrupo1.Size = new Size(300, 60);
            btnGrupo1.Text = "Grupo 1 (Opciones 1-10)";
            btnGrupo1.Font = new Font("Arial", 12);
            btnGrupo1.Click += BtnGrupo1_Click;

            // btnGrupo2
            btnGrupo2.Location = new Point(100, 200);
            btnGrupo2.Size = new Size(300, 60);
            btnGrupo2.Text = "Grupo 2 (Opciones 11-20)";
            btnGrupo2.Font = new Font("Arial", 12);
            btnGrupo2.Click += BtnGrupo2_Click;

            // btnGrupo3
            btnGrupo3.Location = new Point(100, 280);
            btnGrupo3.Size = new Size(300, 60);
            btnGrupo3.Text = "Grupo 3 (Opciones 21-30)";
            btnGrupo3.Font = new Font("Arial", 12);
            btnGrupo3.Click += BtnGrupo3_Click;

            // btnOpcionales
            btnOpcionales.Location = new Point(100, 360);
            btnOpcionales.Size = new Size(300, 60);
            btnOpcionales.Text = "Opciones Adicionales";
            btnOpcionales.Font = new Font("Arial", 12);
            btnOpcionales.BackColor = Color.LightYellow;
            btnOpcionales.Click += BtnOpcionales_Click;

            Controls.Add(lblTitulo);
            Controls.Add(btnGrupo1);
            Controls.Add(btnGrupo2);
            Controls.Add(btnGrupo3);
            Controls.Add(btnOpcionales);

            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 500);
            Name = "Form1";
            Text = "Menú Principal";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
        }

        #endregion
    }
}
