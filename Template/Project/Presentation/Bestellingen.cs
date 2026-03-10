public class Bestellingen
{
    private static BestellingLogic _logic = new();
    private static ProductLogic _productlogic= new();

    public static void Start()
    {
        List<BestellingModel> bestellingen = _logic.AllOrders();
        List<ProductModel> producten = _productlogic.AllProducts();


        foreach(BestellingModel bestelling in bestellingen)
        {
            ProductModel foundproduct = producten.Find(x => x.ProductId == bestelling.ProductId);

            Console.WriteLine($"Name: {foundproduct.ProductName}\nPrice: {foundproduct.Price}\nDetails: {foundproduct.Description}\n");
        }

    }

}