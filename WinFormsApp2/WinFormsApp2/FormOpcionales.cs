namespace WinFormsApp2
{
    public partial class FormOpcionales : Form
    {
        public FormOpcionales()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            Label lblTitulo = new Label
            {
                Text = "OPCIONES ADICIONALES (31-32)",
                Font = new Font("Arial", 18, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 20),
                Size = new Size(500, 50),
                AutoSize = false
            };
            Controls.Add(lblTitulo);

            int yPos = 80;
            string[] ejercicios = new string[]
            {
                "31. Conteo de Deportes",
                "32. Sistema de Claves"
            };

            for (int i = 0; i < ejercicios.Length; i++)
            {
                Button btn = new Button
                {
                    Text = ejercicios[i],
                    Location = new Point(50, yPos),
                    Size = new Size(400, 40),
                    Font = new Font("Arial", 11),
                    Tag = i + 31
                };
                btn.Click += (s, e) => OpenExercise(int.Parse(btn.Tag.ToString()));
                Controls.Add(btn);
                yPos += 50;
            }

            Button btnVolver = new Button
            {
                Text = "Volver al Menú Principal",
                Location = new Point(50, yPos + 10),
                Size = new Size(400, 40),
                Font = new Font("Arial", 11),
                BackColor = Color.LightGray
            };
            btnVolver.Click += (s, e) => this.Close();
            Controls.Add(btnVolver);

            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, yPos + 70);
            Name = "FormOpcionales";
            Text = "Opciones Adicionales - 31-32";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
        }

        private void OpenExercise(int exerciseNumber)
        {
            Form exerciseForm = new Form
            {
                Text = $"Ejercicio {exerciseNumber}",
                Width = 700,
                Height = 500,
                StartPosition = FormStartPosition.CenterParent
            };

            Panel pnl = new Panel { Dock = DockStyle.Fill };
            exerciseForm.Controls.Add(pnl);

            switch (exerciseNumber)
            {
                case 31: CreateExercise31(pnl); break;
                case 32: CreateExercise32(pnl); break;
            }

            exerciseForm.ShowDialog();
        }

        // Ejercicio 31: Conteo de deportes en 10 alumnos
        private void CreateExercise31(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Conteo de Deportes");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Label lblInfo = AddLabel(pnl, 20, 40, "Deportes válidos: VOLEY, FUTBOL, BASQUET, AJEDREZ");
            lblInfo.Font = new Font("Arial", 10, FontStyle.Italic);

            Button btnIniciar = new Button
            {
                Text = "Iniciar Encuesta (10 Alumnos)",
                Location = new Point(20, 70),
                Size = new Size(300, 35),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            pnl.Controls.Add(btnIniciar);

            RichTextBox rtbResult = new RichTextBox
            {
                Location = new Point(20, 120),
                Size = new Size(600, 300),
                ReadOnly = true,
                Font = new Font("Arial", 11)
            };
            pnl.Controls.Add(rtbResult);

            btnIniciar.Click += (s, e) => {
                rtbResult.Clear();
                int voley = 0, futbol = 0, basquet = 0, ajedrez = 0;

                for (int i = 1; i <= 10; i++)
                {
                    string input = PromptDialog("Encuesta de Deportes", $"Ingrese deporte del {i}º alumno:\n(voley, futbol, basquet, ajedrez)");
                    if (string.IsNullOrEmpty(input)) break;

                    string deporte = input.ToLower().Trim();
                    if (deporte == "voley")
                        voley++;
                    else if (deporte == "futbol")
                        futbol++;
                    else if (deporte == "basquet")
                        basquet++;
                    else if (deporte == "ajedrez")
                        ajedrez++;
                    else
                        MessageBox.Show("Deporte no válido. Ingrese: voley, futbol, basquet o ajedrez", "Error");
                }

                rtbResult.AppendText("=== RESUMEN DE ENCUESTA ===\n\n");
                rtbResult.AppendText($"Cantidad de VOLEY: {voley}\n");
                rtbResult.AppendText($"Cantidad de FUTBOL: {futbol}\n");
                rtbResult.AppendText($"Cantidad de BASQUET: {basquet}\n");
                rtbResult.AppendText($"Cantidad de AJEDREZ: {ajedrez}");
            };
        }

        // Ejercicio 32: Sistema de claves (5 palabras)
        private void CreateExercise32(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Sistema de Claves de Acceso");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Label lblInfo = AddLabel(pnl, 20, 40, "Ingrese las 5 palabras clave en orden");
            lblInfo.Font = new Font("Arial", 10, FontStyle.Italic);

            Button btnIniciar = new Button
            {
                Text = "Verificar Acceso",
                Location = new Point(20, 70),
                Size = new Size(300, 35),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            pnl.Controls.Add(btnIniciar);

            Label lblResult = new Label
            {
                Location = new Point(20, 120),
                Size = new Size(600, 250),
                Text = "Ingrese 5 palabras para acceder",
                Font = new Font("Arial", 12, FontStyle.Bold),
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = ContentAlignment.TopLeft,
                Padding = new Padding(10, 10, 0, 0)
            };
            pnl.Controls.Add(lblResult);

            btnIniciar.Click += (s, e) => {
                try
                {
                    string c1 = PromptDialog("Clave 1", "Ingrese primera clave:");
                    if (string.IsNullOrEmpty(c1)) return;

                    if (c1.ToLower() != "tienes")
                    {
                        lblResult.Text = "TE EQUIVOCASTE DE FIESTA";
                        return;
                    }

                    string c2 = PromptDialog("Clave 2", "Ingrese segunda clave:");
                    if (string.IsNullOrEmpty(c2)) return;

                    if (c2.ToLower() != "que ser")
                    {
                        lblResult.Text = "TE EQUIVOCASTE DE FIESTA";
                        return;
                    }

                    string c3 = PromptDialog("Clave 3", "Ingrese tercera clave:");
                    if (string.IsNullOrEmpty(c3)) return;

                    if (c3.ToLower() != "invitado")
                    {
                        lblResult.Text = "TE EQUIVOCASTE DE FIESTA";
                        return;
                    }

                    string c4 = PromptDialog("Clave 4", "Ingrese cuarta clave:");
                    if (string.IsNullOrEmpty(c4)) return;

                    if (c4.ToLower() != "para")
                    {
                        lblResult.Text = "TE EQUIVOCASTE DE FIESTA";
                        return;
                    }

                    string c5 = PromptDialog("Clave 5", "Ingrese quinta clave:");
                    if (string.IsNullOrEmpty(c5)) return;

                    if (c5.ToLower() != "ingresar")
                    {
                        lblResult.Text = "TE EQUIVOCASTE DE FIESTA";
                        return;
                    }

                    lblResult.Text = "BIENVENIDO A LA FIESTA\n\n✓ ¡Todas las claves fueron correctas!";
                }
                catch { lblResult.Text = "Error al procesar las claves"; }
            };
        }

        #region Helper Methods

        private Label AddLabel(Panel pnl, int x, int y, string text)
        {
            Label lbl = new Label { Location = new Point(x, y), Text = text, AutoSize = true };
            pnl.Controls.Add(lbl);
            return lbl;
        }

        private TextBox AddTextBox(Panel pnl, int x, int y)
        {
            TextBox txt = new TextBox { Location = new Point(x, y), Width = 150 };
            pnl.Controls.Add(txt);
            return txt;
        }

        private string PromptDialog(string title, string prompt)
        {
            Form promptForm = new Form()
            {
                Text = title,
                Width = 300,
                Height = 150,
                StartPosition = FormStartPosition.CenterParent
            };
            Label label = new Label() { Left = 20, Top = 20, Text = prompt, Width = 250, AutoSize = false, Height = 50 };
            TextBox textBox = new TextBox() { Left = 20, Top = 70, Width = 240 };
            Button okButton = new Button() { Text = "OK", Left = 150, Width = 110, Top = 100, DialogResult = DialogResult.OK };
            okButton.Click += (sender, e) => { promptForm.Close(); };
            promptForm.Controls.Add(label);
            promptForm.Controls.Add(textBox);
            promptForm.Controls.Add(okButton);
            promptForm.AcceptButton = okButton;
            return promptForm.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        #endregion
    }
}
