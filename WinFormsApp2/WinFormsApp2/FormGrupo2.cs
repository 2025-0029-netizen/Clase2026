namespace WinFormsApp2
{
    public partial class FormGrupo2 : Form
    {
        public FormGrupo2()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            Label lblTitulo = new Label
            {
                Text = "GRUPO 2 (OPCIONES 11-20)",
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
                "11. Cálculo de Factura con IVA",
                "12. Análisis de 50 Números",
                "13. Cálculo de Factorial",
                "14. Media de 100 Números",
                "15. Suma y Producto de Pares",
                "16. Por completar",
                "17. Por completar",
                "18. Primera Vocal Ingresada",
                "19. Verificador de Parte Fraccionaria",
                "20. Soluciones de Ecuación Cuadrática"
            };

            for (int i = 0; i < ejercicios.Length; i++)
            {
                Button btn = new Button
                {
                    Text = ejercicios[i],
                    Location = new Point(50, yPos),
                    Size = new Size(400, 40),
                    Font = new Font("Arial", 11),
                    Tag = i + 11
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
            Name = "FormGrupo2";
            Text = "Grupo 2 - Opciones 11-20";
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
                case 11: CreateExercise11(pnl); break;
                case 12: CreateExercise12(pnl); break;
                case 13: CreateExercise13(pnl); break;
                case 14: CreateExercise14(pnl); break;
                case 15: CreateExercise15(pnl); break;
                case 16: CreateExercise16(pnl); break;
                case 17: CreateExercise17(pnl); break;
                case 18: CreateExercise18(pnl); break;
                case 19: CreateExercise19(pnl); break;
                case 20: CreateExercise20(pnl); break;
            }

            exerciseForm.ShowDialog();
        }

        // Ejercicio 11: Cálculo de factura con IVA y descuento
        private void CreateExercise11(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Cálculo de Factura con IVA");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Label lblPrecio = AddLabel(pnl, 20, 40, "Precio:");
            TextBox txtPrecio = AddTextBox(pnl, 20, 60);

            Label lblCant = AddLabel(pnl, 20, 100, "Cantidad:");
            TextBox txtCant = AddTextBox(pnl, 20, 120);

            Button btnCalc = new Button
            {
                Text = "Calcular Factura",
                Location = new Point(20, 160),
                Size = new Size(300, 35),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            pnl.Controls.Add(btnCalc);

            RichTextBox rtbResult = new RichTextBox
            {
                Location = new Point(20, 210),
                Size = new Size(600, 150),
                ReadOnly = true,
                Font = new Font("Arial", 10)
            };
            pnl.Controls.Add(rtbResult);

            btnCalc.Click += (s, e) => {
                try
                {
                    double precio = double.Parse(txtPrecio.Text);
                    double numeroarticulos = double.Parse(txtCant.Text);
                    double precioventa = precio * numeroarticulos;
                    double iva = Math.Round(precioventa * 0.15, 2);
                    double preciobruto = precioventa + iva;
                    double descuento = preciobruto >= 50 ? Math.Round((preciobruto * 5) / 100, 2) : 0;
                    double totalpagar = preciobruto - descuento;

                    rtbResult.Clear();
                    rtbResult.AppendText($"--- FACTURA ---\n");
                    rtbResult.AppendText($"Precio unitario: ${precio:F2}\n");
                    rtbResult.AppendText($"Cantidad: {numeroarticulos}\n");
                    rtbResult.AppendText($"Precio venta: ${precioventa:F2}\n");
                    rtbResult.AppendText($"IVA (15%): ${iva:F2}\n");
                    rtbResult.AppendText($"Precio bruto: ${preciobruto:F2}\n");
                    rtbResult.AppendText($"Descuento (5%): ${descuento:F2}\n");
                    rtbResult.AppendText($"TOTAL A PAGAR: ${totalpagar:F2}");
                }
                catch { rtbResult.Text = "Valores inválidos"; }
            };
        }

        // Ejercicio 12: Análisis de 50 números
        private void CreateExercise12(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Análisis de 50 Números");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Button btnIniciar = new Button
            {
                Text = "Iniciar Análisis",
                Location = new Point(20, 40),
                Size = new Size(300, 35),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            pnl.Controls.Add(btnIniciar);

            Label lblResult = new Label
            {
                Location = new Point(20, 100),
                Size = new Size(600, 200),
                Text = "Resultado:",
                Font = new Font("Arial", 11),
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = ContentAlignment.TopLeft,
                Padding = new Padding(10, 10, 0, 0)
            };
            pnl.Controls.Add(lblResult);

            btnIniciar.Click += (s, e) => {
                int pares = 0, impares = 0, positivos = 0, negativos = 0;

                for (int x = 1; x <= 50; x++)
                {
                    string input = PromptDialog($"Número {x} de 50", $"Ingrese el número {x}:");
                    if (!int.TryParse(input, out int numero)) continue;

                    if (numero % 2 == 0) pares++; else impares++;
                    if (numero > 0) positivos++; else negativos++;
                }

                lblResult.Text = $"Números Pares: {pares}\nNúmeros Impares: {impares}\nNúmeros Positivos: {positivos}\nNúmeros Negativos: {negativos}";
            };
        }

        // Ejercicio 15: Suma y producto de pares 20-30
        private void CreateExercise15(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Suma y Producto de Pares");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Label lblInfo = AddLabel(pnl, 20, 40, "Rango: Números pares del 20 al 30");
            lblInfo.Font = new Font("Arial", 10);

            Button btnCalc = new Button
            {
                Text = "Calcular",
                Location = new Point(20, 80),
                Size = new Size(300, 35),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            pnl.Controls.Add(btnCalc);

            RichTextBox rtbResult = new RichTextBox
            {
                Location = new Point(20, 130),
                Size = new Size(600, 200),
                ReadOnly = true,
                Font = new Font("Arial", 10)
            };
            pnl.Controls.Add(rtbResult);

            btnCalc.Click += (s, e) => {
                int suma = 0, producto = 1;
                string numeros = "";
                for (int x = 20; x <= 30; x += 2)
                {
                    suma += x;
                    producto *= x;
                    numeros += $"{x} ";
                }
                rtbResult.Clear();
                rtbResult.AppendText($"Números pares: {numeros}\n\n");
                rtbResult.AppendText($"Suma: {suma}\n");
                rtbResult.AppendText($"Producto: {producto}");
            };
        }

        // Ejercicios 16-20: Placeholders
        private void CreateExercise16(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Ejercicio 16");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);
            AddLabel(pnl, 20, 50, "Por completar - Código fuente necesario");
        }

        private void CreateExercise17(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Ejercicio 17");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);
            AddLabel(pnl, 20, 50, "Por completar - Código fuente necesario");
        }

        // Ejercicio 18: Primera vocal ingresada
        private void CreateExercise18(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Primera Vocal Ingresada");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Button btnIniciar = new Button
            {
                Text = "Iniciar Búsqueda",
                Location = new Point(20, 40),
                Size = new Size(300, 35),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            pnl.Controls.Add(btnIniciar);

            Label lblResult = new Label
            {
                Location = new Point(20, 100),
                Size = new Size(600, 150),
                Text = "Resultado:",
                Font = new Font("Arial", 11),
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = ContentAlignment.TopLeft,
                Padding = new Padding(10, 10, 0, 0)
            };
            pnl.Controls.Add(lblResult);

            btnIniciar.Click += (s, e) => {
                int x = 1;
                string caracter = "";
                do
                {
                    string input = PromptDialog("Ingrese carácter", "Ingrese un carácter:");
                    if (string.IsNullOrEmpty(input)) break;
                    caracter = input[0].ToString().ToLower();
                    if (caracter == "a" || caracter == "e" || caracter == "i" || caracter == "o" || caracter == "u")
                        x = 0;
                }
                while (x == 1);

                if (string.IsNullOrEmpty(caracter))
                    lblResult.Text = "Búsqueda cancelada";
                else
                    lblResult.Text = $"La primera vocal ingresada fue: {caracter}";
            };
        }

        // Ejercicio 19: Verificar parte fraccionaria
        private void CreateExercise19(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Verificador de Parte Fraccionaria");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Label lblNum = AddLabel(pnl, 20, 40, "Número:");
            TextBox txtNum = AddTextBox(pnl, 20, 60);

            Button btnCalc = new Button
            {
                Text = "Verificar",
                Location = new Point(20, 110),
                Size = new Size(300, 35),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            pnl.Controls.Add(btnCalc);

            Label lblResult = new Label
            {
                Location = new Point(20, 160),
                Size = new Size(600, 120),
                Text = "Resultado:",
                Font = new Font("Arial", 11),
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = ContentAlignment.TopLeft,
                Padding = new Padding(10, 10, 0, 0)
            };
            pnl.Controls.Add(lblResult);

            btnCalc.Click += (s, e) => {
                try
                {
                    double numero = double.Parse(txtNum.Text);
                    double pf = Math.Truncate(numero);
                    if (numero == pf)
                        lblResult.Text = $"Número: {numero}\nNo tiene parte fraccionaria";
                    else
                        lblResult.Text = $"Número: {numero}\nTiene parte fraccionaria";
                }
                catch { lblResult.Text = "Valor inválido"; }
            };
        }

        // Ejercicio 20: Soluciones de ecuación cuadrática
        private void CreateExercise20(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Soluciones de Ecuación Cuadrática");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Label lblInfo = AddLabel(pnl, 20, 40, "aX² + bX + c = 0");
            lblInfo.Font = new Font("Arial", 10);

            Label lblA = AddLabel(pnl, 20, 65, "Coeficiente a:");
            TextBox txtA = AddTextBox(pnl, 150, 65);

            Label lblB = AddLabel(pnl, 20, 105, "Coeficiente b:");
            TextBox txtB = AddTextBox(pnl, 150, 105);

            Label lblC = AddLabel(pnl, 20, 145, "Coeficiente c:");
            TextBox txtC = AddTextBox(pnl, 150, 145);

            Button btnCalc = new Button
            {
                Text = "Calcular Soluciones",
                Location = new Point(20, 185),
                Size = new Size(300, 35),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            pnl.Controls.Add(btnCalc);

            RichTextBox rtbResult = new RichTextBox
            {
                Location = new Point(20, 230),
                Size = new Size(600, 200),
                ReadOnly = true,
                Font = new Font("Arial", 10)
            };
            pnl.Controls.Add(rtbResult);

            btnCalc.Click += (s, e) => {
                try
                {
                    double coefA = double.Parse(txtA.Text);
                    double coefB = double.Parse(txtB.Text);
                    double coefC = double.Parse(txtC.Text);

                    rtbResult.Clear();
                    if (coefA == 0)
                    {
                        rtbResult.AppendText("Esta no es una ecuación cuadrática.\nEl coeficiente 'a' debe ser diferente de 0");
                    }
                    else
                    {
                        double disc = Math.Pow(coefB, 2) - 4 * coefA * coefC;
                        if (disc > 0)
                        {
                            double s1 = Math.Round((-coefB + Math.Sqrt(disc)) / (2 * coefA), 2);
                            double s2 = Math.Round((-coefB - Math.Sqrt(disc)) / (2 * coefA), 2);
                            rtbResult.AppendText($"Discriminante: {disc:F2}\n");
                            rtbResult.AppendText($"El discriminante es positivo.\n");
                            rtbResult.AppendText($"Soluciones reales distintas:\n");
                            rtbResult.AppendText($"X₁ = {s1}\n");
                            rtbResult.AppendText($"X₂ = {s2}");
                        }
                        else if (disc == 0)
                        {
                            double s3 = Math.Round(-coefB / (2 * coefA), 2);
                            rtbResult.AppendText($"Discriminante: {disc:F2}\n");
                            rtbResult.AppendText($"El discriminante es 0.\n");
                            rtbResult.AppendText($"Solución única:\n");
                            rtbResult.AppendText($"X = {s3}");
                        }
                        else
                        {
                            double raizReal = Math.Round(-coefB / (2 * coefA), 4);
                            double raizImag = Math.Round(Math.Sqrt(Math.Abs(disc)) / (2 * coefA), 4);
                            rtbResult.AppendText($"Discriminante: {disc:F2}\n");
                            rtbResult.AppendText($"El discriminante es negativo.\n");
                            rtbResult.AppendText($"Soluciones complejas conjugadas:\n");
                            rtbResult.AppendText($"X₁ = {raizReal} + {raizImag}i\n");
                            rtbResult.AppendText($"X₂ = {raizReal} - {raizImag}i");
                        }
                    }
                }
                catch { rtbResult.Text = "Valores inválidos"; }
            };
        }

        // Ejercicio 13: Factorial
        private void CreateExercise13(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Cálculo de Factorial");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Label lblNum = AddLabel(pnl, 20, 40, "Número:");
            TextBox txtNum = AddTextBox(pnl, 20, 60);

            Button btnCalc = new Button
            {
                Text = "Calcular Factorial",
                Location = new Point(20, 110),
                Size = new Size(300, 35),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            pnl.Controls.Add(btnCalc);

            Label lblResult = new Label
            {
                Location = new Point(20, 160),
                Size = new Size(600, 120),
                Text = "Resultado:",
                Font = new Font("Arial", 11),
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = ContentAlignment.TopLeft,
                Padding = new Padding(10, 10, 0, 0)
            };
            pnl.Controls.Add(lblResult);

            btnCalc.Click += (s, e) => {
                try
                {
                    int numero = int.Parse(txtNum.Text);
                    int factorial = 1;
                    for (int i = 1; i <= numero; i++)
                        factorial = factorial * i;
                    lblResult.Text = $"Número: {numero}\n{numero}! = {factorial}";
                }
                catch { lblResult.Text = "Valor inválido"; }
            };
        }

        // Ejercicio 14: Media de 100 números
        private void CreateExercise14(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Media de 100 Números");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Button btnIniciar = new Button
            {
                Text = "Iniciar Ingreso de 100 Números",
                Location = new Point(20, 40),
                Size = new Size(300, 35),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            pnl.Controls.Add(btnIniciar);

            Label lblResult = new Label
            {
                Location = new Point(20, 100),
                Size = new Size(600, 150),
                Text = "Resultado:",
                Font = new Font("Arial", 11),
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = ContentAlignment.TopLeft,
                Padding = new Padding(10, 10, 0, 0)
            };
            pnl.Controls.Add(lblResult);

            btnIniciar.Click += (s, e) => {
                double suma = 0;
                bool cancelado = false;
                for (int x = 1; x <= 100; x++)
                {
                    string input = PromptDialog($"Número {x} de 100", $"Ingrese el número {x}:");
                    if (string.IsNullOrEmpty(input))
                    {
                        cancelado = true;
                        break;
                    }
                    if (double.TryParse(input, out double numero))
                        suma += numero;
                }
                if (cancelado)
                    lblResult.Text = "Operación cancelada";
                else
                {
                    double media = Math.Round(suma / 100, 2);
                    lblResult.Text = $"Suma total: {suma:F2}\nCantidad de números: 100\nMedia de los 100 números ingresados: {media:F2}";
                }
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

        private Button AddButton(Panel pnl, int x, int y, string text)
        {
            Button btn = new Button { Location = new Point(x, y), Text = text, Width = 100 };
            pnl.Controls.Add(btn);
            return btn;
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
            Label label = new Label() { Left = 20, Top = 20, Text = prompt, Width = 250 };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 240 };
            Button okButton = new Button() { Text = "OK", Left = 150, Width = 110, Top = 80, DialogResult = DialogResult.OK };
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
