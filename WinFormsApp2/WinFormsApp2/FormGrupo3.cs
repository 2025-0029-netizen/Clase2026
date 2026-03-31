namespace WinFormsApp2
{
    public partial class FormGrupo3 : Form
    {
        public FormGrupo3()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            Label lblTitulo = new Label
            {
                Text = "GRUPO 3 (OPCIONES 21-30)",
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
                "21. Operaciones Básicas (10 Procesos)",
                "22. Cubo y Raíz Cuadrada",
                "23. Operaciones Básicas con Validación",
                "24. Área de Triángulo (Heron)",
                "25. Hipotenusa de Triángulo Rectángulo",
                "26. Circunferencia (Longitud, Área, Volumen)",
                "27. Suma de Consumos con Descuento",
                "28. Suma de Serie (Desde 8)",
                "29. Egresos de Caja",
                "30. Promedio de Dos Notas"
            };

            for (int i = 0; i < ejercicios.Length; i++)
            {
                Button btn = new Button
                {
                    Text = ejercicios[i],
                    Location = new Point(50, yPos),
                    Size = new Size(400, 40),
                    Font = new Font("Arial", 11),
                    Tag = i + 21
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
            Name = "FormGrupo3";
            Text = "Grupo 3 - Opciones 21-30";
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
                case 21: CreateExercise21(pnl); break;
                case 22: CreateExercise22(pnl); break;
                case 23: CreateExercise23(pnl); break;
                case 24: CreateExercise24(pnl); break;
                case 25: CreateExercise25(pnl); break;
                case 26: CreateExercise26(pnl); break;
                case 27: CreateExercise27(pnl); break;
                case 28: CreateExercise28(pnl); break;
                case 29: CreateExercise29(pnl); break;
                case 30: CreateExercise30(pnl); break;
            }

            exerciseForm.ShowDialog();
        }

        // Ejercicio 21: Operaciones básicas (10 procesos)
        private void CreateExercise21(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Operaciones Básicas (10 Procesos)");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Button btnIniciar = new Button
            {
                Text = "Iniciar 10 Procesos",
                Location = new Point(20, 40),
                Size = new Size(300, 35),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            pnl.Controls.Add(btnIniciar);

            RichTextBox rtbResult = new RichTextBox
            {
                Location = new Point(20, 90),
                Size = new Size(600, 320),
                ReadOnly = true,
                Font = new Font("Arial", 9)
            };
            pnl.Controls.Add(rtbResult);

            btnIniciar.Click += (s, e) => {
                rtbResult.Clear();
                for (int c = 1; c <= 10; c++)
                {
                    string input1 = PromptDialog($"Proceso {c}", "Ingrese primer número:");
                    if (string.IsNullOrEmpty(input1)) break;
                    if (!double.TryParse(input1, out double num1)) continue;

                    string input2 = PromptDialog($"Proceso {c}", "Ingrese segundo número:");
                    if (string.IsNullOrEmpty(input2)) break;
                    if (!double.TryParse(input2, out double num2)) continue;

                    double suma = num1 + num2;
                    double resta = num1 - num2;
                    double multiplicacion = num1 * num2;
                    double division = Math.Round(num2 != 0 ? num1 / num2 : 0, 2);

                    rtbResult.AppendText($"PROCESO Nº{c}:\n");
                    rtbResult.AppendText($"Num1: {num1}, Num2: {num2}\n");
                    rtbResult.AppendText($"Suma: {suma}\n");
                    rtbResult.AppendText($"Resta: {resta}\n");
                    rtbResult.AppendText($"Multiplicación: {multiplicacion}\n");
                    rtbResult.AppendText($"División: {division}\n\n");
                }
            };
        }

        // Ejercicio 22: Cubo y Raíz Cuadrada
        private void CreateExercise22(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Cubo y Raíz Cuadrada");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Button btnIniciar = new Button
            {
                Text = "Iniciar (Ingrese 0 para salir)",
                Location = new Point(20, 40),
                Size = new Size(300, 35),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            pnl.Controls.Add(btnIniciar);

            RichTextBox rtbResult = new RichTextBox
            {
                Location = new Point(20, 90),
                Size = new Size(600, 320),
                ReadOnly = true,
                Font = new Font("Arial", 10)
            };
            pnl.Controls.Add(rtbResult);

            btnIniciar.Click += (s, e) => {
                rtbResult.Clear();
                int c = 0;
                double numero = 1;
                while (numero != 0)
                {
                    string input = PromptDialog($"Proceso {c + 1}", "Ingrese un número (0 para salir):");
                    if (string.IsNullOrEmpty(input)) break;
                    if (!double.TryParse(input, out numero)) continue;

                    if (numero != 0)
                    {
                        c++;
                        double cubo = Math.Pow(numero, 3);
                        double raizcuadrada = Math.Round(Math.Sqrt(Math.Abs(numero)), 2);
                        rtbResult.AppendText($"PROCESO Nº{c}:\n");
                        rtbResult.AppendText($"El cubo es: {cubo}\n");
                        rtbResult.AppendText($"La raíz cuadrada es: {raizcuadrada}\n\n");
                    }
                }
                rtbResult.AppendText("FIN DEL PROCESO");
            };
        }

        // Ejercicio 23: Operaciones Básicas con Validación
        private void CreateExercise23(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Operaciones Básicas con Validación");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Button btnIniciar = new Button
            {
                Text = "Iniciar (Ingrese 0 para salir)",
                Location = new Point(20, 40),
                Size = new Size(300, 35),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            pnl.Controls.Add(btnIniciar);

            RichTextBox rtbResult = new RichTextBox
            {
                Location = new Point(20, 90),
                Size = new Size(600, 320),
                ReadOnly = true,
                Font = new Font("Arial", 10)
            };
            pnl.Controls.Add(rtbResult);

            btnIniciar.Click += (s, e) => {
                rtbResult.Clear();
                int c = 0;
                double num1 = 1;
                while (num1 != 0)
                {
                    string input1 = PromptDialog($"Proceso {c + 1}", "Ingrese primer número (0 para salir):");
                    if (string.IsNullOrEmpty(input1)) break;
                    if (!double.TryParse(input1, out num1)) continue;

                    if (num1 != 0)
                    {
                        c++;
                        string input2 = PromptDialog($"Proceso {c}", "Ingrese segundo número:");
                        if (string.IsNullOrEmpty(input2)) break;
                        if (!double.TryParse(input2, out double num2)) continue;

                        double suma = num1 + num2;
                        double resta = num1 - num2;
                        double multiplicacion = num1 * num2;
                        double division = Math.Round(num2 != 0 ? num1 / num2 : 0, 2);

                        rtbResult.AppendText($"PROCESO Nº{c}:\n");
                        rtbResult.AppendText($"La suma es: {suma}\n");
                        rtbResult.AppendText($"La resta es: {resta}\n");
                        rtbResult.AppendText($"La multiplicación es: {multiplicacion}\n");
                        rtbResult.AppendText($"La división es: {division}\n\n");
                    }
                }
                rtbResult.AppendText("FINAL DEL PROCESO");
            };
        }

        // Ejercicio 24: Área de Triángulo (Heron)
        private void CreateExercise24(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Área de Triángulo (Fórmula de Heron)");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Label lblA = AddLabel(pnl, 20, 40, "Lado A:");
            TextBox txtA = AddTextBox(pnl, 150, 40);

            Label lblB = AddLabel(pnl, 20, 80, "Lado B:");
            TextBox txtB = AddTextBox(pnl, 150, 80);

            Label lblC = AddLabel(pnl, 20, 120, "Lado C:");
            TextBox txtC = AddTextBox(pnl, 150, 120);

            Button btnCalc = new Button
            {
                Text = "Calcular Área",
                Location = new Point(20, 160),
                Size = new Size(300, 35),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            pnl.Controls.Add(btnCalc);

            Label lblResult = new Label
            {
                Location = new Point(20, 210),
                Size = new Size(600, 100),
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
                    double ladoa = double.Parse(txtA.Text);
                    double ladob = double.Parse(txtB.Text);
                    double ladoc = double.Parse(txtC.Text);
                    double sm = (ladoa + ladob + ladoc) / 2;
                    double areatriangulo = Math.Round(Math.Sqrt(sm * (sm - ladoa) * (sm - ladob) * (sm - ladoc)), 2);
                    lblResult.Text = $"Lados: {ladoa}, {ladob}, {ladoc}\nSemiperimetro: {sm}\nÁrea del triángulo: {areatriangulo}";
                }
                catch { lblResult.Text = "Valores inválidos"; }
            };
        }

        // Ejercicio 25: Hipotenusa
        private void CreateExercise25(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Hipotenusa de Triángulo Rectángulo");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Label lblA = AddLabel(pnl, 20, 40, "Primer Cateto:");
            TextBox txtA = AddTextBox(pnl, 150, 40);

            Label lblB = AddLabel(pnl, 20, 80, "Segundo Cateto:");
            TextBox txtB = AddTextBox(pnl, 150, 80);

            Button btnCalc = new Button
            {
                Text = "Calcular Hipotenusa",
                Location = new Point(20, 120),
                Size = new Size(300, 35),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            pnl.Controls.Add(btnCalc);

            Label lblResult = new Label
            {
                Location = new Point(20, 170),
                Size = new Size(600, 100),
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
                    double cateoa = double.Parse(txtA.Text);
                    double catetob = double.Parse(txtB.Text);
                    double hipotenusa = Math.Round(Math.Sqrt(Math.Pow(cateoa, 2) + Math.Pow(catetob, 2)), 2);
                    lblResult.Text = $"Cateto A: {cateoa}\nCateto B: {catetob}\nLa hipotenusa es: {hipotenusa}";
                }
                catch { lblResult.Text = "Valores inválidos"; }
            };
        }

        // Ejercicio 26: Circunferencia
        private void CreateExercise26(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Circunferencia (Longitud, Área, Volumen)");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Label lblR = AddLabel(pnl, 20, 40, "Radio:");
            TextBox txtR = AddTextBox(pnl, 150, 40);

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
                Size = new Size(600, 250),
                ReadOnly = true,
                Font = new Font("Arial", 10)
            };
            pnl.Controls.Add(rtbResult);

            btnCalc.Click += (s, e) => {
                try
                {
                    double pi = 3.14;
                    double radio = double.Parse(txtR.Text);
                    double longitud = 2 * pi * radio;
                    double area = Math.Round(pi * Math.Pow(radio, 2), 2);
                    double volumen = Math.Round((4.0 / 3.0) * pi * Math.Pow(radio, 3), 2);

                    rtbResult.Clear();
                    rtbResult.AppendText($"Radio: {radio}\n\n");
                    rtbResult.AppendText($"Longitud de la circunferencia: {longitud}\n");
                    rtbResult.AppendText($"Área de la circunferencia: {area}\n");
                    rtbResult.AppendText($"Volumen de la esfera: {volumen}");
                }
                catch { rtbResult.Text = "Valor inválido"; }
            };
        }

        // Ejercicio 27: Suma de Consumos
        private void CreateExercise27(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Suma de Consumos con Descuento");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);
            Label lblInfo = AddLabel(pnl, 20, 40, "(130 consumos) Descuento si > 130: 15%");

            Button btnIniciar = new Button
            {
                Text = "Iniciar",
                Location = new Point(20, 70),
                Size = new Size(300, 35),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            pnl.Controls.Add(btnIniciar);

            Label lblResult = new Label
            {
                Location = new Point(20, 120),
                Size = new Size(600, 100),
                Text = "Resultado:",
                Font = new Font("Arial", 11),
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = ContentAlignment.TopLeft,
                Padding = new Padding(10, 10, 0, 0)
            };
            pnl.Controls.Add(lblResult);

            btnIniciar.Click += (s, e) => {
                double total = 0;
                for (int c = 1; c <= 130; c++)
                {
                    string input = PromptDialog($"Consumo {c}", $"Ingrese consumo {c}:");
                    if (string.IsNullOrEmpty(input)) break;
                    if (!double.TryParse(input, out double consumo)) continue;

                    double descuento = consumo > 130 ? consumo * 0.15 : 0;
                    consumo = consumo - descuento;
                    total += consumo;
                }
                lblResult.Text = $"El total de los consumos es: ${total:F2}\nFIN DEL PROCESO";
            };
        }

        // Ejercicio 28: Suma de Serie desde 8
        private void CreateExercise28(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Suma de Serie (Desde 8)");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Label lblNum = AddLabel(pnl, 20, 40, "Número:");
            TextBox txtNum = AddTextBox(pnl, 150, 40);

            Button btnCalc = new Button
            {
                Text = "Calcular",
                Location = new Point(20, 80),
                Size = new Size(300, 35),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            pnl.Controls.Add(btnCalc);

            Label lblResult = new Label
            {
                Location = new Point(20, 130),
                Size = new Size(600, 150),
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
                    if (numero < 8)
                        lblResult.Text = "Error: el número ingresado es menor a 8";
                    else
                    {
                        int suma = 0;
                        for (int x = 8; x <= numero; x++)
                            suma += x;
                        lblResult.Text = $"La suma de la serie de rango 8 hasta {numero}, con incremento de 1 es: {suma}";
                    }
                }
                catch { lblResult.Text = "Valor inválido"; }
            };
        }

        // Ejercicio 29: Egresos de Caja
        private void CreateExercise29(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Egresos de Caja (Inicial: $371)");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);
            Label lblInfo = AddLabel(pnl, 20, 40, "Ingrese -1 para finalizar");

            Button btnIniciar = new Button
            {
                Text = "Iniciar",
                Location = new Point(20, 70),
                Size = new Size(300, 35),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            pnl.Controls.Add(btnIniciar);

            RichTextBox rtbResult = new RichTextBox
            {
                Location = new Point(20, 120),
                Size = new Size(600, 250),
                ReadOnly = true,
                Font = new Font("Arial", 10)
            };
            pnl.Controls.Add(rtbResult);

            btnIniciar.Click += (s, e) => {
                double caja = 371;
                double totalegresos = 0;
                int cont = 0;
                double egreso = 0;

                rtbResult.Clear();
                do
                {
                    cont++;
                    string input = PromptDialog($"Egreso {cont}", $"Ingrese egreso {cont} (-1 para finalizar):");
                    if (string.IsNullOrEmpty(input)) break;
                    if (!double.TryParse(input, out egreso)) continue;

                    if (egreso != -1)
                    {
                        totalegresos += egreso;
                    }
                }
                while (egreso != -1);

                double restocaja = caja - totalegresos;
                rtbResult.AppendText($"Caja inicial: ${caja}\n");
                rtbResult.AppendText($"Total de egresos: ${totalegresos}\n");
                rtbResult.AppendText($"Lo sobrante en caja es: ${restocaja}");
            };
        }

        // Ejercicio 30: Promedio de Dos Notas
        private void CreateExercise30(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Promedio de Dos Notas");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Label lblN1 = AddLabel(pnl, 20, 40, "Nota 1:");
            TextBox txtN1 = AddTextBox(pnl, 150, 40);

            Label lblN2 = AddLabel(pnl, 20, 80, "Nota 2:");
            TextBox txtN2 = AddTextBox(pnl, 150, 80);

            Button btnCalc = new Button
            {
                Text = "Calcular",
                Location = new Point(20, 120),
                Size = new Size(300, 35),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            pnl.Controls.Add(btnCalc);

            RichTextBox rtbResult = new RichTextBox
            {
                Location = new Point(20, 170),
                Size = new Size(600, 150),
                ReadOnly = true,
                Font = new Font("Arial", 10)
            };
            pnl.Controls.Add(rtbResult);

            btnCalc.Click += (s, e) => {
                try
                {
                    double nota1 = double.Parse(txtN1.Text);
                    double nota2 = double.Parse(txtN2.Text);

                    if (nota1 >= 0 && nota1 <= 20 && nota2 >= 0 && nota2 <= 20)
                    {
                        double promedio = (nota1 + nota2) / 2;
                        string estado = promedio >= 10.5 ? "Aprobado" : "Desaprobado";
                        rtbResult.Clear();
                        rtbResult.AppendText($"Nota 1: {nota1}\n");
                        rtbResult.AppendText($"Nota 2: {nota2}\n");
                        rtbResult.AppendText($"Promedio: {promedio}\n");
                        rtbResult.AppendText($"Estado: {estado}");
                    }
                    else
                        rtbResult.Text = "ERROR: Las notas deben estar entre 0-20 (escala vigesimal)";
                }
                catch { rtbResult.Text = "Valores inválidos"; }
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
