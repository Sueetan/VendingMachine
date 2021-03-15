namespace iQuest.VendingMachine.Model
{
    public class Product
    {
        public int ProductID { get; }
        public string Name { get; }
        public double Price { get; }
        public int Quantity { get; set; }

        public Product(int productID, string name, double price, int quantity)
        {
            ProductID = productID;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
