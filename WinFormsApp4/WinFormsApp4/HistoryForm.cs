using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class HistoryForm : Form
    {
        public HistoryForm(List<SaleRecord> salesHistory)
        {
            InitializeComponent();
            LoadHistory(salesHistory);
        }

        private void LoadHistory(List<SaleRecord> salesHistory)
        {
            dataGridViewHistory.AutoGenerateColumns = false;
            dataGridViewHistory.Columns.Clear();
            dataGridViewHistory.AllowUserToAddRows = false;

            DataGridViewTextBoxColumn saleNumberColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SaleNumber",
                HeaderText = "Venta #",
                Width = 80,
                ReadOnly = true
            };

            DataGridViewTextBoxColumn dateColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SaleDate",
                HeaderText = "Fecha y Hora",
                Width = 180,
                ReadOnly = true
            };

            DataGridViewTextBoxColumn itemCountColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ItemCount",
                HeaderText = "Items",
                Width = 70,
                ReadOnly = true
            };

            DataGridViewTextBoxColumn totalColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalAmount",
                HeaderText = "Total",
                Width = 100,
                ReadOnly = true
            };

            DataGridViewTextBoxColumn detailsColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Details",
                HeaderText = "Detalles",
                Width = 350,
                ReadOnly = true
            };

            dataGridViewHistory.Columns.Add(saleNumberColumn);
            dataGridViewHistory.Columns.Add(dateColumn);
            dataGridViewHistory.Columns.Add(itemCountColumn);
            dataGridViewHistory.Columns.Add(totalColumn);
            dataGridViewHistory.Columns.Add(detailsColumn);

            var orderedHistory = salesHistory.OrderByDescending(s => s.SaleDate).ToList();
            dataGridViewHistory.DataSource = orderedHistory;
        }

        private void InitializeComponent()
        {
            dataGridViewHistory = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistory).BeginInit();
            SuspendLayout();
            
            dataGridViewHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHistory.Dock = DockStyle.Fill;
            dataGridViewHistory.Location = new Point(0, 0);
            dataGridViewHistory.Name = "dataGridViewHistory";
            dataGridViewHistory.RowHeadersVisible = false;
            dataGridViewHistory.Size = new Size(800, 450);
            dataGridViewHistory.TabIndex = 0;
            
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewHistory);
            Name = "HistoryForm";
            Text = "Histórico de Ventas";
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistory).EndInit();
            ResumeLayout(false);
        }

        private DataGridView dataGridViewHistory;
    }
}
