public class ProductModel
{

    public Int64 ProductId { get; set; }
    public string ProductName { get; set; }

    public string Description { get; set; }

    public string Keywords { get; set; }
    public double Price { get; set; }


    public ProductModel(){ }


    public ProductModel(string productname, string description, string keywords, double price)
    {
        ProductName = productname;
        Description = description;
        Keywords = keywords;
        Price = price;
    }

}



