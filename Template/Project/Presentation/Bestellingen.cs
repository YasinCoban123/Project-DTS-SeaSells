public class Bestellingen
{
    private static BestellingLogic _logic = new();
    // private ProductLogic _productlogic= new();

    public static void Start()
    {
        List<BestellingModel> bestellingen = _logic.AllOrders();
        List<ProductModel> producten = _productlogic.AllOrders();


        foreach(BestellingModel bestelling in bestellingen)
        {

            Console.WriteLine($"ID: {bestelling.Id}, ");
        }

    }

}