using System.Runtime.CompilerServices;

static class Store
{
    static private AccountsLogic accountsLogic = new AccountsLogic();
    static private StoreLogic storelogic = new StoreLogic();

    public static void Start()
    {
        Console.Clear();
        Console.WriteLine("Welcome to our store");
        Console.WriteLine("[1] See all products");
        Console.WriteLine("[2] Search products");
        Console.WriteLine("[3] Back to menu");

        string? choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.Clear();
            AllProducts();
        }
        else if (choice == "2")
        {
            Console.Clear();
            SearchProduct();
        }
        else if (choice == "3")
        {
            Console.Clear();
            Menu.Start();
        }
        else
        {
            Console.Clear();
            Start();
        }
    }

    public static void AllProducts()
    {
        Console.Clear();
        var products = storelogic.GetAllProducts();

        if (products.Count == 0)
        {
            Console.WriteLine("No products found.");
        }
        else
        {
            Console.Clear();
            Console.WriteLine("All Products\n");
            foreach (var p in products)
            {
                Console.WriteLine($"[{p.ProductId}] {p.ProductName}");
                Console.WriteLine(p.Description);
                Console.WriteLine($"Price: €{p.Price}");
                Console.WriteLine("——————————————————————————————————");
            }
        }
        Console.WriteLine("Press ENTER to continue");
        Console.ReadLine();
        Console.Clear();
        Start();

        // Console.WriteLine("\n[0] Back");
        // string? choice = Console.ReadLine();

        // if (choice == "0")
        // {
        //     Start();
        // }
        // else
        // {
        //     Start();
        // }
    }

    public static void SearchProduct()
    {
        Console.Clear();

        Console.WriteLine("Enter search term:");
        string input = Console.ReadLine();

        var results = storelogic.SearchProducts(input);

        Console.Clear();

        if (results.Count == 0)
        {
            Console.WriteLine("No products found.");
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
            Console.Clear();
            Start();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Results from search\n");

            foreach (var p in results)
            {
                Console.WriteLine($"[{p.ProductId}] {p.ProductName}");
                Console.WriteLine(p.Description);
                Console.WriteLine($"Price: €{p.Price}");
                Console.WriteLine("——————————————————————————————————");
            }
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
            Console.Clear();
            Start();
        }
    }
}