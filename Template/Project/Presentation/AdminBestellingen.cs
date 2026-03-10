public class AdminBestellingen
{
    private static BestellingLogic _logic = new();
    private static ProductLogic _productlogic= new();

    public static void Start()
    {
        Console.Clear();
        Console.WriteLine("[1] See all Orders");
        Console.WriteLine("[2] Remove an order");
        string choice = Console.ReadLine();

        switch(choice)
        {
            case "1":
                SeeAllOrders();
                break;
            case "2":
                RemoveAnOrder();
                break;
        }

    }

    public static void SeeAllOrders()
    {
        List<BestellingModel> bestellingen = _logic.AllOrders();
        foreach(BestellingModel bestelling in bestellingen)
        {
            Console.WriteLine($"ID: {bestelling.ProductId}\nPrice: {bestelling.ProductId}\nUser.Id: {bestelling.UserId}\n");
        }

    }

    public static void RemoveAnOrder()
    {
        List<BestellingModel> bestellingen = _logic.AllOrders();
        Console.WriteLine();
        Console.WriteLine("Give an Id of an order to remove it");
        string choice = Console.ReadLine();
        int choiceint = Convert.ToInt32(choice);
        BestellingModel gekozenbestellingen = bestellingen.Find(x => x.Id == choiceint);
        _logic.Delete(gekozenbestellingen);
        Menu.AdminStart();
    }
}