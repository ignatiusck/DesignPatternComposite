class Program
{
    public static void Main(string[] args)
    {
        Product product_1 = new() { Name = "Fish", Price = 5000 };
        Product product_2 = new() { Name = "Apple", Price = 1500 };
        Product product_3 = new() { Name = "Vegetable", Price = 2000 };

        Box Box_1 = new() { BoxName = "Fish Box" };
        Box_1.Add(product_1);
        Box_1.Add(product_1);
        Box_1.Add(product_1);

        Box Box_2 = new() { BoxName = "Apple Box" };
        Box_2.Add(product_2);
        Box_2.Add(product_2);

        Box PackingBox = new() { BoxName = "Packing" };
        PackingBox.Add(Box_1);
        PackingBox.Add(Box_2);
        PackingBox.Add(product_3);

        Console.WriteLine($"Apple Price: {Box_2.TotalPrice()}");
        Console.WriteLine($"Fish Price: {Box_1.TotalPrice()}");
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

        public decimal TotalPrice()
        {
            return Price;
        }
    }



    class Box : IProduct
    {
        private decimal _totalPrice;
        public string BoxName { get; set; }
        public List<IProduct> List = new();

        public void Add(IProduct product)
        {
            List.Add(product);
        }

        public void Remove(IProduct product)
        {
            List.Remove(product);
        }

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