namespace WinFormsApp4
{
    public class CartItem
    {
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total => UnitPrice * Quantity;

        public CartItem(int menuItemId, string name, decimal unitPrice, int quantity = 1)
        {
            MenuItemId = menuItemId;
            Name = name;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }
    }
}
