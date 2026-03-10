public class Bestellingen
{
    private static BestellingLogic _logic = new();
    private static ProductLogic _productlogic = new();

    public static void Start()
    {
        Console.Clear();
        Console.WriteLine("=== Your Orders ===\n");

        List<BestellingModel> bestellingen = _logic.GetMyOrders();
        List<ProductModel> producten = _productlogic.AllProducts();

        if (bestellingen.Count == 0)
        {
            Console.WriteLine("You have no orders yet.");
        }
        else
        {
            foreach (BestellingModel bestelling in bestellingen)
            {
                ProductModel foundproduct = producten.Find(x => x.ProductId == bestelling.ProductId);
                if (foundproduct != null)
                {
                    Console.WriteLine($"Name:    {foundproduct.ProductName}");
                    Console.WriteLine($"Price:   €{foundproduct.Price}");
                    Console.WriteLine($"Details: {foundproduct.Description}");
                    Console.WriteLine("——————————————————————————————————");
                }
            }
        }

        Console.WriteLine("\nPress ENTER to go back to the menu...");
        Console.ReadLine();
        Console.Clear();
        Menu.Start();
    }
}