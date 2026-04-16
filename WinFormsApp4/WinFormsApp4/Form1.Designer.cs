namespace WinFormsApp4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            panelMenu = new Panel();
            labelMenuTitle = new Label();
            flowLayoutPanelMenu = new FlowLayoutPanel();
            panelCart = new Panel();
            buttonHistory = new Button();
            buttonClear = new Button();
            buttonBuy = new Button();
            labelPayment = new Label();
            comboBoxPayment = new ComboBox();
            labelTotalLabel = new Label();
            labelTotalAmount = new Label();
            dataGridViewCart = new DataGridView();
            labelCartTitle = new Label();
            panelMenu.SuspendLayout();
            panelCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCart).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Control;
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 0;
            button1.Text = "Bebidas";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(130, 12);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 1;
            button2.Text = "Comida";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(248, 12);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 2;
            button3.Text = "Pasteles";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // panelMenu
            // 
            panelMenu.BorderStyle = BorderStyle.FixedSingle;
            panelMenu.Controls.Add(labelMenuTitle);
            panelMenu.Controls.Add(flowLayoutPanelMenu);
            panelMenu.Location = new Point(12, 52);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(541, 571);
            panelMenu.TabIndex = 3;
            // 
            // labelMenuTitle
            // 
            labelMenuTitle.AutoSize = true;
            labelMenuTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelMenuTitle.Location = new Point(3, 2);
            labelMenuTitle.Name = "labelMenuTitle";
            labelMenuTitle.Size = new Size(79, 30);
            labelMenuTitle.TabIndex = 0;
            labelMenuTitle.Text = "MENÚ";
            labelMenuTitle.Click += labelMenuTitle_Click;
            // 
            // flowLayoutPanelMenu
            // 
            flowLayoutPanelMenu.AutoScroll = true;
            flowLayoutPanelMenu.Location = new Point(3, 35);
            flowLayoutPanelMenu.Name = "flowLayoutPanelMenu";
            flowLayoutPanelMenu.Size = new Size(518, 520);
            flowLayoutPanelMenu.TabIndex = 1;
            flowLayoutPanelMenu.Paint += flowLayoutPanelMenu_Paint;
            // 
            // panelCart
            // 
            panelCart.BorderStyle = BorderStyle.FixedSingle;
            panelCart.Controls.Add(buttonHistory);
            panelCart.Controls.Add(buttonClear);
            panelCart.Controls.Add(buttonBuy);
            panelCart.Controls.Add(labelPayment);
            panelCart.Controls.Add(comboBoxPayment);
            panelCart.Controls.Add(labelTotalLabel);
            panelCart.Controls.Add(labelTotalAmount);
            panelCart.Controls.Add(dataGridViewCart);
            panelCart.Controls.Add(labelCartTitle);
            panelCart.Location = new Point(583, 52);
            panelCart.Name = "panelCart";
            panelCart.Size = new Size(517, 571);
            panelCart.TabIndex = 4;
            // 
            // buttonHistory
            // 
            buttonHistory.BackColor = Color.Purple;
            buttonHistory.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonHistory.ForeColor = Color.White;
            buttonHistory.Location = new Point(10, 436);
            buttonHistory.Name = "buttonHistory";
            buttonHistory.Size = new Size(444, 40);
            buttonHistory.TabIndex = 8;
            buttonHistory.Text = "VER HISTÓRICO";
            buttonHistory.UseVisualStyleBackColor = false;
            buttonHistory.Click += ButtonShowHistory_Click;
            // 
            // buttonClear
            // 
            buttonClear.BackColor = Color.FromArgb(255, 128, 128);
            buttonClear.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonClear.ForeColor = Color.White;
            buttonClear.Location = new Point(226, 390);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(228, 40);
            buttonClear.TabIndex = 7;
            buttonClear.Text = "LIMPIAR";
            buttonClear.UseVisualStyleBackColor = false;
            buttonClear.Click += ButtonClearCart_Click;
            // 
            // buttonBuy
            // 
            buttonBuy.BackColor = Color.LimeGreen;
            buttonBuy.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonBuy.ForeColor = Color.White;
            buttonBuy.Location = new Point(10, 390);
            buttonBuy.Name = "buttonBuy";
            buttonBuy.Size = new Size(210, 40);
            buttonBuy.TabIndex = 6;
            buttonBuy.Text = "COMPRAR";
            buttonBuy.UseVisualStyleBackColor = false;
            buttonBuy.Click += ButtonCheckout_Click;
            // 
            // labelPayment
            // 
            labelPayment.AutoSize = true;
            labelPayment.Font = new Font("Segoe UI", 9F);
            labelPayment.Location = new Point(10, 351);
            labelPayment.Name = "labelPayment";
            labelPayment.Size = new Size(56, 25);
            labelPayment.TabIndex = 4;
            labelPayment.Text = "Pago:";
            labelPayment.Click += labelPayment_Click;
            // 
            // comboBoxPayment
            // 
            comboBoxPayment.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPayment.FormattingEnabled = true;
            comboBoxPayment.Items.AddRange(new object[] { "Efectivo", "Tarjeta", "Transferencia" });
            comboBoxPayment.Location = new Point(67, 348);
            comboBoxPayment.Name = "comboBoxPayment";
            comboBoxPayment.Size = new Size(150, 33);
            comboBoxPayment.TabIndex = 5;
            // 
            // labelTotalLabel
            // 
            labelTotalLabel.AutoSize = true;
            labelTotalLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTotalLabel.Location = new Point(10, 301);
            labelTotalLabel.Name = "labelTotalLabel";
            labelTotalLabel.Size = new Size(64, 28);
            labelTotalLabel.TabIndex = 2;
            labelTotalLabel.Text = "Total:";
            labelTotalLabel.Click += labelTotalLabel_Click;
            // 
            // labelTotalAmount
            // 
            labelTotalAmount.AutoSize = true;
            labelTotalAmount.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelTotalAmount.ForeColor = Color.Green;
            labelTotalAmount.Location = new Point(67, 301);
            labelTotalAmount.Name = "labelTotalAmount";
            labelTotalAmount.Size = new Size(89, 38);
            labelTotalAmount.TabIndex = 3;
            labelTotalAmount.Text = "$0.00";
            labelTotalAmount.Click += labelTotalAmount_Click;
            // 
            // dataGridViewCart
            // 
            dataGridViewCart.AllowUserToAddRows = false;
            dataGridViewCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCart.Location = new Point(10, 43);
            dataGridViewCart.Name = "dataGridViewCart";
            dataGridViewCart.RowHeadersVisible = false;
            dataGridViewCart.RowHeadersWidth = 62;
            dataGridViewCart.Size = new Size(484, 250);
            dataGridViewCart.TabIndex = 1;
            // 
            // labelCartTitle
            // 
            labelCartTitle.AutoSize = true;
            labelCartTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelCartTitle.ForeColor = Color.DeepSkyBlue;
            labelCartTitle.Location = new Point(10, 10);
            labelCartTitle.Name = "labelCartTitle";
            labelCartTitle.Size = new Size(241, 30);
            labelCartTitle.TabIndex = 0;
            labelCartTitle.Text = "CARRITO DE COMPRA";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1150, 679);
            Controls.Add(panelCart);
            Controls.Add(panelMenu);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Sistema de Venta - Restaurante";
            Load += Form1_Load;
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            panelCart.ResumeLayout(false);
            panelCart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCart).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Panel panelMenu;
        private Panel panelCart;
        private Label labelMenuTitle;
        private Label labelCartTitle;
        private FlowLayoutPanel flowLayoutPanelMenu;
        private DataGridView dataGridViewCart;
        private Label labelTotalAmount;
        private Label labelTotalLabel;
        private ComboBox comboBoxPayment;
        private Label labelPayment;
        private Button buttonBuy;
        private Button buttonClear;
        private Button buttonHistory;
    }
}
