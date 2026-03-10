public class AdminProducts
{
    private static ProductLogic _productlogic= new();
    static List<ProductModel> producten => _productlogic.AllProducts();

    public static void Start()
    {
        Console.Clear();
        Console.WriteLine("[1]See all products");
        Console.WriteLine("[2]Add a product");
        Console.WriteLine("[3]Delete a product");
        string choice = Console.ReadLine();
        switch(choice)
        {
            case "1":
                SeeAllProducts();
                break;
            case "2":
                AddProducts();
                break;
            case "3":
                // DeleteProduct();
                break;
        }
    }

    public static void SeeAllProducts()
    {
        foreach(ProductModel product in producten)
        {
            Console.WriteLine();
            Console.WriteLine($"Name {product.ProductName}\nDescription {product.Description}\nPrice {product.Price}\n");
        }
    }

    public static void AddProducts()
    {
        Console.Clear();
        Console.WriteLine("Give the name of a product");
        string chosenname = Console.ReadLine();
        Console.WriteLine($"Give a description for {chosenname}");
        string chosendesc = Console.ReadLine();
        Console.WriteLine("Give a few keywords to search for the product (Comma separated!)");
        string chosenwords = Console.ReadLine();
        Console.WriteLine("Give the price of the product");
        string chosenprice = Console.ReadLine();
        int chosenpriceint = Convert.ToInt32(chosenprice);

        ProductModel newproduct = new ProductModel(chosenname, chosendesc, chosenwords, chosenpriceint);

        _productlogic.AddAProduct(newproduct);
        
    }
    
    public void DeleteProducts()
    {
        Console.WriteLine("Give the ide");
        
    }
}