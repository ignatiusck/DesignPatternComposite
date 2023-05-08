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