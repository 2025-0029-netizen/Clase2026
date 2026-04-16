namespace WinFormsApp4
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }

        public MenuItem(int id, string name, string category, decimal price, string description, int stock = 100)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
            Description = description;
            Stock = stock;
        }
    }
}
