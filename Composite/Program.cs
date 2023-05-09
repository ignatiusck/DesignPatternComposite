static class Program
{
    public static void Main(string[] args)
    {
        Product Fish = new() { Name = "Fish", Price = 5000 };
        Product Apple = new() { Name = "Apple", Price = 1500 };
        Product Vegetable = new() { Name = "Vegetable", Price = 2000 };

        Box Box_1 = new() { BoxName = "Fish Box" };
        Box_1.AddProduct(Fish);
        Box_1.AddProduct(Fish);
        Box_1.AddProduct(Fish);

        Box Box_2 = new() { BoxName = "Apple Box" };
        Box_2.AddProduct(Apple);
        Box_2.AddProduct(Apple);

        Box PackingBox = new() { BoxName = "Packing" };
        PackingBox.AddProduct(Box_1);
        PackingBox.AddProduct(Box_2);
        PackingBox.AddProduct(Vegetable);

        Console.WriteLine($"Fish box Price: {Box_1.TotalPrice()}");
        Console.WriteLine($"Apple box Price: {Box_2.TotalPrice()}");
        Console.WriteLine($"Total Price: {PackingBox.TotalPrice()}");

        PackingBox.RemoveProduct(Box_1);
        Console.WriteLine($"Total Price: {PackingBox.TotalPrice()}");
    }


    interface IProduct
    {
        decimal TotalPrice();
    }


    class Product : IProduct
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }

        //execute
        public decimal TotalPrice()
        {
            return Price;
        }
    }



    class Box : IProduct
    {
        private decimal _totalPrice;
        public string? BoxName { get; set; }
        public List<IProduct> List = new();

        //add
        public void AddProduct(IProduct product)
        {
            List.Add(product);
        }

        //remove
        public void RemoveProduct(IProduct product)
        {
            List.Remove(product);
        }

        //execute
        public decimal TotalPrice()
        {
            _totalPrice = 0;
            foreach (IProduct item in List)
            {
                _totalPrice += item.TotalPrice();
            }
            return _totalPrice;
        }
    }
}