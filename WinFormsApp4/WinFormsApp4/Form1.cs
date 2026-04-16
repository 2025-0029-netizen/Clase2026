using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        private List<MenuItem> menuItems;
        private List<CartItem> cartItems;
        private List<SaleRecord> salesHistory;
        private Dictionary<int, NumericUpDown> quantityControls;
        private string currentCategory = "Bebidas";
        private int saleCounter = 0;
        private Form historyForm;

        public Form1()
        {
            InitializeComponent();
            cartItems = new List<CartItem>();
            salesHistory = new List<SaleRecord>();
            quantityControls = new Dictionary<int, NumericUpDown>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeMenuItems();
            SetupCartDataGridView();
            LoadMenuByCategory("Bebidas");
            button2.Click += Button2_Click;
        }

        private void InitializeMenuItems()
        {
            menuItems = new List<MenuItem>
            {
                // Bebidas
                new MenuItem(1, "Agua", "Bebidas", 1.50m, "Agua natural", 100),
                new MenuItem(2, "Jugo de Naranja", "Bebidas", 2.50m, "Jugo natural de naranja", 100),
                new MenuItem(3, "Jugo de Manzana", "Bebidas", 2.50m, "Jugo natural de manzana", 100),
                new MenuItem(4, "Refresco", "Bebidas", 2.00m, "Refrescos variados", 100),
                new MenuItem(5, "Café", "Bebidas", 2.00m, "Café caliente", 100),
                new MenuItem(6, "Té", "Bebidas", 1.50m, "Té variado", 100),

                // Comida
                new MenuItem(7, "Ensalada César", "Comida", 8.50m, "Lechuga, pollo y queso", 100),
                new MenuItem(8, "Hamburguesa", "Comida", 9.99m, "Carne, queso, tomate y lechuga", 100),
                new MenuItem(9, "Pasta Carbonara", "Comida", 10.50m, "Pasta con crema y bacon", 100),
                new MenuItem(10, "Pechuga de Pollo", "Comida", 12.00m, "Con vegetales al vapor", 100),
                new MenuItem(11, "Filete de Salmón", "Comida", 14.99m, "Con limón y hierbas", 100),
                new MenuItem(12, "Pizza Margarita", "Comida", 11.00m, "Mozzarella, tomate y albahaca", 100),

                // Pasteles
                new MenuItem(13, "Flan", "Pasteles", 3.50m, "Flan casero con caramelo", 100),
                new MenuItem(14, "Brownie", "Pasteles", 4.00m, "Brownie de chocolate", 100),
                new MenuItem(15, "Cheesecake", "Pasteles", 4.50m, "Cheesecake de fresas", 100),
                new MenuItem(16, "Tiramisú", "Pasteles", 5.00m, "Tiramisú italiano", 100),
                new MenuItem(17, "Helado", "Pasteles", 3.00m, "Helado variado", 100),
                new MenuItem(18, "Mousse de Chocolate", "Pasteles", 4.50m, "Mousse cremoso", 100)
            };
        }

        private void SetupCartDataGridView()
        {
            dataGridViewCart.AutoGenerateColumns = false;
            dataGridViewCart.Columns.Clear();
            dataGridViewCart.AllowUserToAddRows = false;

            DataGridViewTextBoxColumn productColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Producto",
                Width = 180,
                ReadOnly = true
            };

            DataGridViewTextBoxColumn quantityColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Cantidad",
                Width = 70,
                ReadOnly = true
            };

            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UnitPrice",
                HeaderText = "Precio",
                Width = 80,
                ReadOnly = true
            };

            DataGridViewTextBoxColumn totalColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Total",
                HeaderText = "Total",
                Width = 100,
                ReadOnly = true
            };

            dataGridViewCart.Columns.Add(productColumn);
            dataGridViewCart.Columns.Add(quantityColumn);
            dataGridViewCart.Columns.Add(priceColumn);
            dataGridViewCart.Columns.Add(totalColumn);
        }

        private void LoadMenuByCategory(string category)
        {
            currentCategory = category;
            flowLayoutPanelMenu.Controls.Clear();
            quantityControls.Clear();

            var filteredItems = menuItems.Where(m => m.Category == category).ToList();

            foreach (var item in filteredItems)
            {
                Panel itemPanel = new Panel
                {
                    Width = 440,
                    Height = 120,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(0, 0, 0, 5)
                };

                Label nameLabel = new Label
                {
                    Text = item.Name,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Location = new Point(10, 8),
                    AutoSize = true
                };

                Label priceLabel = new Label
                {
                    Text = $"${item.Price:F2}",
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    ForeColor = Color.Green,
                    Location = new Point(10, 32),
                    AutoSize = true
                };

                Label stockLabel = new Label
                {
                    Text = $"Stock: {item.Stock}",
                    Font = new Font("Segoe UI", 8),
                    ForeColor = Color.Gray,
                    Location = new Point(10, 50),
                    AutoSize = true
                };

                NumericUpDown quantity = new NumericUpDown
                {
                    Minimum = 0,
                    Maximum = item.Stock,
                    Value = 0,
                    Location = new Point(300, 30),
                    Width = 60
                };

                Button addButton = new Button
                {
                    Text = "Agregar",
                    Location = new Point(360, 30),
                    Width = 70,
                    Height = 24,
                    BackColor = Color.DeepSkyBlue,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 8)
                };

                addButton.Click += (sender, e) =>
                {
                    if (quantity.Value > 0)
                    {
                        AddToCart(item, (int)quantity.Value);
                        quantity.Value = 0;
                    }
                    else
                    {
                        MessageBox.Show("Ingrese una cantidad válida", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                };

                itemPanel.Controls.Add(nameLabel);
                itemPanel.Controls.Add(priceLabel);
                itemPanel.Controls.Add(stockLabel);
                itemPanel.Controls.Add(quantity);
                itemPanel.Controls.Add(addButton);

                flowLayoutPanelMenu.Controls.Add(itemPanel);
            }
        }

        private void AddToCart(MenuItem item, int quantity)
        {
            var existingItem = cartItems.FirstOrDefault(c => c.MenuItemId == item.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cartItems.Add(new CartItem(item.Id, item.Name, item.Price, quantity));
            }

            RefreshCart();
        }

        private void RefreshCart()
        {
            dataGridViewCart.DataSource = null;
            dataGridViewCart.DataSource = cartItems.ToList();

            decimal total = cartItems.Sum(c => c.Total);
            labelTotalAmount.Text = $"${total:F2}";
        }

        private void ButtonCheckout_Click(object sender, EventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("El carrito está vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal total = cartItems.Sum(c => c.Total);
            string paymentMethod = comboBoxPayment.SelectedItem?.ToString() ?? "Efectivo";
            DialogResult result = MessageBox.Show($"¿Confirmar venta por ${total:F2}?\nMétodo de pago: {paymentMethod}", "Procesar Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                saleCounter++;
                string details = string.Join(" | ", cartItems.Select(c => $"{c.Name} x{c.Quantity}"));

                var saleRecord = new SaleRecord(saleCounter, DateTime.Now, cartItems.Count, total, details);
                salesHistory.Add(saleRecord);

                MessageBox.Show($"¡Venta #{saleCounter} procesada exitosamente!\nTotal: ${total:F2}\nMétodo: {paymentMethod}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cartItems.Clear();
                RefreshCart();
            }
        }

        private void ButtonClearCart_Click(object sender, EventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("El carrito ya está vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("¿Desea vaciar el carrito?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cartItems.Clear();
                RefreshCart();
            }
        }

        private void ButtonShowHistory_Click(object sender, EventArgs e)
        {
            if (historyForm == null || historyForm.IsDisposed)
            {
                historyForm = new HistoryForm(salesHistory);
            }
            historyForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadMenuByCategory("Bebidas");
        }

        private void Button2_Click(object? sender, EventArgs e)
        {
            LoadMenuByCategory("Comida");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadMenuByCategory("Pasteles");
        }

        private void labelPayment_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelMenuTitle_Click(object sender, EventArgs e)
        {

        }

        private void labelTotalLabel_Click(object sender, EventArgs e)
        {

        }

        private void labelTotalAmount_Click(object sender, EventArgs e)
        {

        }
    }
}
