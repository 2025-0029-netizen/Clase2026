namespace WinFormsApp2
{
    public partial class FormGrupo1 : Form
    {
        public FormGrupo1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            Label lblTitulo = new Label
            {
                Text = "GRUPO 1 (OPCIONES 1-10)",
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
                "1. Cálculo de Salario",
                "2. Cálculo de Descuentos",
                "3. Calculador de Descuentos por Monto",
                "4. Convertidor Segundos a Minutos",
                "5. Convertidor Minutos a Días/Horas",
                "6. Suma de Serie",
                "7. Suma de Salarios de Trabajadores",
                "8. Cálculo Simple de Salario",
                "9. Análisis de Notas",
                "10. Suma de Dígitos"
            };

            for (int i = 0; i < ejercicios.Length; i++)
            {
                Button btn = new Button
                {
                    Text = ejercicios[i],
                    Location = new Point(50, yPos),
                    Size = new Size(400, 40),
                    Font = new Font("Arial", 11),
                    Tag = i + 1
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
            Name = "FormGrupo1";
            Text = "Grupo 1 - Opciones 1-10";
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
                case 1: CreateExercise1(pnl); break;
                case 2: CreateExercise2(pnl); break;
                case 3: CreateExercise3(pnl); break;
                case 4: CreateExercise4(pnl); break;
                case 5: CreateExercise5(pnl); break;
                case 6: CreateExercise6(pnl); break;
                case 7: CreateExercise7(pnl); break;
                case 8: CreateExercise8(pnl); break;
                case 9: CreateExercise9(pnl); break;
                case 10: CreateExercise10(pnl); break;
            }

            exerciseForm.ShowDialog();
        }

        // Ejercicio 1: Cálculo de salario con horas extra
        private void CreateExercise1(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Cálculo de Salario");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Label lblHoras = AddLabel(pnl, 20, 40, "Horas Trabajadas:");
            TextBox txtHoras = AddTextBox(pnl, 20, 60);

            Label lblTarifa = AddLabel(pnl, 20, 100, "Tarifa:");
            TextBox txtTarifa = AddTextBox(pnl, 20, 120);

            Button btnCalc = new Button
            {
                Text = "Calcular Salario",
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
                    double horastrabajadas = double.Parse(txtHoras.Text);
                    double tarifa = double.Parse(txtTarifa.Text);
                    double salario, horasextra, tarifaextra;

                    if (horastrabajadas <= 40 && horastrabajadas >= 0)
                    {
                        salario = horastrabajadas * tarifa;
                        lblResult.Text = $"El salario es: ${salario:F2}";
                    }
                    else if (horastrabajadas > 40)
                    {
                        horasextra = horastrabajadas - 40;
                        tarifaextra = tarifa + 0.5 * tarifa;
                        salario = horasextra * tarifaextra + 40 * tarifa;
                        lblResult.Text = $"Horas extra: {horasextra}\nTarifa extra: ${tarifaextra:F2}\nSalario total: ${salario:F2}";
                    }
                    else
                    {
                        lblResult.Text = "Las horas trabajadas no pueden ser negativas";
                    }
                }
                catch { lblResult.Text = "Por favor ingrese valores numéricos válidos"; }
            };
        }

        // Ejercicio 2: Sueldo neto con descuentos escalonados
        private void CreateExercise2(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Cálculo de Descuentos");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Label lblSueldo = AddLabel(pnl, 20, 40, "Sueldo:");
            TextBox txtSueldo = AddTextBox(pnl, 20, 60);

            Button btnCalc = new Button
            {
                Text = "Calcular",
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
                    double sueldo = double.Parse(txtSueldo.Text);
                    double descuento, sueldoneto;

                    if (sueldo <= 1000 && sueldo >= 0)
                    {
                        descuento = sueldo * 0.1;
                        sueldoneto = sueldo - descuento;
                    }
                    else if (sueldo <= 2000)
                    {
                        descuento = (sueldo - 1000) * 0.05 + (1000 * 0.1);
                        sueldoneto = sueldo - descuento;
                    }
                    else
                    {
                        descuento = (sueldo - 2000) * 0.03 + (1000 * 0.05) + (1000 * 0.1);
                        sueldoneto = sueldo - descuento;
                    }
                    lblResult.Text = $"Sueldo: ${sueldo:F2}\nDescuento: ${descuento:F2}\nSueldo neto: ${sueldoneto:F2}";
                }
                catch { lblResult.Text = "Valor inválido"; }
            };
        }

        // Ejercicio 3: Descuento por monto
        private void CreateExercise3(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Calculador de Descuentos por Monto");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Label lblMonto = AddLabel(pnl, 20, 40, "Monto:");
            TextBox txtMonto = AddTextBox(pnl, 20, 60);

            Button btnCalc = new Button
            {
                Text = "Calcular Descuento",
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
                    double monto = double.Parse(txtMonto.Text);
                    double descuento;

                    if (monto > 100)
                    {
                        descuento = monto * 0.1;
                        lblResult.Text = $"Monto: ${monto:F2}\nDescuento (10%): ${descuento:F2}\nTotal a pagar: ${monto - descuento:F2}";
                    }
                    else if (monto > 0)
                    {
                        descuento = monto * 0.2;
                        lblResult.Text = $"Monto: ${monto:F2}\nDescuento (20%): ${descuento:F2}\nTotal a pagar: ${monto - descuento:F2}";
                    }
                    else
                    {
                        lblResult.Text = "Error: monto no puede ser negativo";
                    }
                }
                catch { lblResult.Text = "Valor inválido"; }
            };
        }

        // Ejercicio 4: Conversión de segundos a minutos
        private void CreateExercise4(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Convertidor Segundos a Minutos");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Label lblSegs = AddLabel(pnl, 20, 40, "Segundos:");
            TextBox txtSegs = AddTextBox(pnl, 20, 60);

            Button btnCalc = new Button
            {
                Text = "Convertir",
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
                    int tiemposegundos = int.Parse(txtSegs.Text);
                    if (tiemposegundos < 60 && tiemposegundos > 0)
                    {
                        int segundosrestantes = 60 - tiemposegundos;
                        lblResult.Text = $"Segundos ingresados: {tiemposegundos}\nLe falta {segundosrestantes} segundos para convertirse en minuto";
                    }
                    else if (tiemposegundos >= 60)
                    {
                        int minutos = tiemposegundos / 60;
                        int segundosrestantes = tiemposegundos % 60;
                        lblResult.Text = $"Segundos ingresados: {tiemposegundos}\nEquivale a {minutos} minutos y {segundosrestantes} segundos";
                    }
                    else
                        lblResult.Text = "Valor debe ser positivo";
                }
                catch { lblResult.Text = "Valor inválido"; }
            };
        }

        // Ejercicio 5: Conversión de minutos a días, horas y minutos
        private void CreateExercise5(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Convertidor Minutos a Días/Horas");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Label lblTiempo = AddLabel(pnl, 20, 40, "Tiempo (minutos):");
            TextBox txtTiempo = AddTextBox(pnl, 20, 60);

            Button btnCalc = new Button
            {
                Text = "Convertir",
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
                    int tiempo = int.Parse(txtTiempo.Text);
                    if (tiempo >= 0)
                    {
                        int dias = tiempo / 1440;
                        int x = tiempo % 1440;
                        int horas = x / 60;
                        int minutos = x % 60;
                        lblResult.Text = $"Minutos ingresados: {tiempo}\nEquivale a:\n{dias} días, {horas} horas y {minutos} minutos";
                    }
                    else
                        lblResult.Text = "El tiempo no puede ser negativo";
                }
                catch { lblResult.Text = "Valor inválido"; }
            };
        }

        // Ejercicio 6: Suma de serie numérica
        private void CreateExercise6(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Suma de Serie");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Label lblNum = AddLabel(pnl, 20, 40, "Número N:");
            TextBox txtNum = AddTextBox(pnl, 20, 60);

            Button btnCalc = new Button
            {
                Text = "Calcular Suma",
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
                    int suma = 0;
                    for (int x = 1; x <= numero; x++)
                        suma += x;
                    lblResult.Text = $"Número N: {numero}\nLa suma de la serie (1 a {numero}) es: {suma}";
                }
                catch { lblResult.Text = "Valor inválido"; }
            };
        }

        // Ejercicio 7: Suma de salarios
        private void CreateExercise7(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Suma de Salarios de Trabajadores");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Label lblNum = AddLabel(pnl, 20, 40, "Ingrese la cantidad de");
            TextBox txtNum = AddTextBox(pnl, 20, 60);
            txtNum.Width = 300;

            Button btnCalc = new Button
            {
                Text = "Calcular Suma de Salarios",
                Location = new Point(20, 100),
                Size = new Size(300, 35),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            pnl.Controls.Add(btnCalc);

            RichTextBox rtbDatos = new RichTextBox
            {
                Location = new Point(20, 145),
                Size = new Size(600, 200),
                ReadOnly = false,
                Font = new Font("Arial", 10)
            };
            pnl.Controls.Add(rtbDatos);

            Label lblResult = new Label
            {
                Location = new Point(20, 355),
                Size = new Size(600, 60),
                Text = "",
                Font = new Font("Arial", 12, FontStyle.Bold),
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0)
            };
            pnl.Controls.Add(lblResult);

            btnCalc.Click += (s, e) => {
                try
                {
                    rtbDatos.Clear();
                    int numerotrabajadores = int.Parse(txtNum.Text);
                    double suma = 0;

                    for (int x = 1; x <= numerotrabajadores; x++)
                    {
                        string input = PromptDialog($"Trabajador {x}", "Ingrese horas trabajadas, tarifa (formato: horas,tarifa)");
                        if (string.IsNullOrEmpty(input)) break;

                        var parts = input.Split(',');
                        if (parts.Length == 2 && double.TryParse(parts[0].Trim(), out double horas) && double.TryParse(parts[1].Trim(), out double tarifa))
                        {
                            double salario = horas * tarifa;
                            suma += salario;
                            rtbDatos.AppendText($"------- Trabajador {x} -------\n");
                            rtbDatos.AppendText($"Horas trabajadas: {horas}\n");
                            rtbDatos.AppendText($"Tarifa: ${tarifa:F2}\n");
                            rtbDatos.AppendText($"Salario: ${salario:F2}\n\n");
                        }
                    }
                    lblResult.Text = $"La suma de los salarios es: ${suma:F2}";
                }
                catch { lblResult.Text = "Error en los datos"; }
            };
        }

        // Ejercicio 8: Cálculo simple de salario
        private void CreateExercise8(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Cálculo Simple de Salario");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Label lblHoras = AddLabel(pnl, 20, 40, "Horas:");
            TextBox txtHoras = AddTextBox(pnl, 20, 60);

            Label lblTarifa = AddLabel(pnl, 20, 100, "Tarifa:");
            TextBox txtTarifa = AddTextBox(pnl, 20, 120);

            Button btnCalc = new Button
            {
                Text = "Calcular Salario",
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
                    double horastrabajadas = double.Parse(txtHoras.Text);
                    double tarifa = double.Parse(txtTarifa.Text);
                    double salario = horastrabajadas * tarifa;
                    lblResult.Text = $"Horas: {horastrabajadas}\nTarifa: ${tarifa:F2}\nSalario total: ${salario:F2}";
                }
                catch { lblResult.Text = "Valores inválidos"; }
            };
        }

        // Ejercicio 9: Promedio de notas
        private void CreateExercise9(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Análisis de Notas");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Button btnAgregar = new Button
            {
                Text = "Agregar Nota",
                Location = new Point(20, 40),
                Size = new Size(140, 35),
                Font = new Font("Arial", 10)
            };
            pnl.Controls.Add(btnAgregar);

            Button btnCalcular = new Button
            {
                Text = "Calcular Promedios",
                Location = new Point(170, 40),
                Size = new Size(150, 35),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            pnl.Controls.Add(btnCalcular);

            RichTextBox rtbNotas = new RichTextBox
            {
                Location = new Point(20, 85),
                Size = new Size(600, 150),
                ReadOnly = false,
                Font = new Font("Arial", 10)
            };
            pnl.Controls.Add(rtbNotas);

            Label lblResult = new Label
            {
                Location = new Point(20, 245),
                Size = new Size(600, 120),
                Text = "Resultado:",
                Font = new Font("Arial", 11),
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = ContentAlignment.TopLeft,
                Padding = new Padding(10, 10, 0, 0)
            };
            pnl.Controls.Add(lblResult);

            List<double> notas = new List<double>();

            btnAgregar.Click += (s, e) => {
                string input = PromptDialog("Agregar Nota", "Ingrese la nota:");
                if (double.TryParse(input, out double nota))
                {
                    notas.Add(nota);
                    rtbNotas.AppendText($"Nota {notas.Count}: {nota}\n");
                }
                else
                    MessageBox.Show("Ingrese un valor numérico válido", "Error");
            };

            btnCalcular.Click += (s, e) => {
                if (notas.Count == 0) { lblResult.Text = "No hay notas registradas"; return; }

                double aprobadas = 0, desaprobadas = 0, sumaApro = 0, sumaDesapro = 0;
                foreach (var nota in notas)
                {
                    if (nota > 10.5)
                    {
                        aprobadas++;
                        sumaApro += nota;
                    }
                    else
                    {
                        desaprobadas++;
                        sumaDesapro += nota;
                    }
                }

                double promApro = aprobadas > 0 ? sumaApro / aprobadas : 0;
                double promDesapro = desaprobadas > 0 ? sumaDesapro / desaprobadas : 0;
                double promGeneral = (sumaApro + sumaDesapro) / notas.Count;

                lblResult.Text = $"Notas aprobadas: {aprobadas} (Promedio: {promApro:F2})\n" +
                                 $"Notas desaprobadas: {desaprobadas} (Promedio: {promDesapro:F2})\n" +
                                 $"Promedio general: {promGeneral:F2}";
            };
        }

        // Ejercicio 10: Suma de dígitos
        private void CreateExercise10(Panel pnl)
        {
            Label lblTitulo = AddLabel(pnl, 20, 10, "Suma de Dígitos");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            Label lblNum = AddLabel(pnl, 20, 40, "Número:");
            TextBox txtNum = AddTextBox(pnl, 20, 60);

            Button btnCalc = new Button
            {
                Text = "Calcular Suma",
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
                    int suma = 0;
                    int temp = Math.Abs(numero);
                    while (temp != 0)
                    {
                        suma += temp % 10;
                        temp /= 10;
                    }
                    lblResult.Text = $"Número: {numero}\nLa suma de los dígitos es: {suma}";
                }
                catch { lblResult.Text = "Valor inválido"; }
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
