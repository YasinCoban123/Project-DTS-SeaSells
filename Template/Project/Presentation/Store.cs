using System.Runtime.CompilerServices;

static class Store
{
    static private StoreLogic storelogic = new StoreLogic();
    static private BasketLogic basketLogic = new BasketLogic();
    static private BestellingLogic bestellingLogic = new BestellingLogic();

    public static void Start()
    {
        Console.Clear();
        Console.WriteLine("Welcome to our store");
        Console.WriteLine("[1] See all products");
        Console.WriteLine("[2] Search products");
        Console.WriteLine("[3] View basket");
        Console.WriteLine("[4] Back to menu");
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
            ViewBasket();
        }
        else if (choice == "4")
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
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
            Console.Clear();
            Start();
            return;
        }

        Console.WriteLine("All Products\n");
        foreach (var p in products)
        {
            Console.WriteLine($"[{p.ProductId}] {p.ProductName}");
            Console.WriteLine(p.Description);
            Console.WriteLine($"Price: €{p.Price}");
            Console.WriteLine("——————————————————————————————————");
        }

        Console.WriteLine("\nEnter a Product ID to view details, or press ENTER to go back:");
        string? input = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(input) && long.TryParse(input, out long productId))
        {
            ProductModel selected = products.FirstOrDefault(p => p.ProductId == productId);
            if (selected != null)
            {
                ProductDetails(selected);
                return;
            }
            else
            {
                Console.WriteLine("Product not found. Press ENTER to continue.");
                Console.ReadLine();
            }
        }

        Console.Clear();
        Start();
    }

    public static void ProductDetails(ProductModel product)
    {
        Console.Clear();
        Console.WriteLine("=== Product Details ===\n");
        Console.WriteLine($"Name:        {product.ProductName}");
        Console.WriteLine($"Description: {product.Description}");
        Console.WriteLine($"Price:       €{product.Price}");
        Console.WriteLine("——————————————————————————————————");
        Console.WriteLine("\n[1] Add to Basket");
        Console.WriteLine("[2] Back to product list");

        string? choice = Console.ReadLine();

        if (choice == "1")
        {
            basketLogic.AddProductToBasket(product.ProductId);
            Console.Clear();
            Console.WriteLine($"'{product.ProductName}' has been added to your basket!");
            Console.WriteLine("\nPress ENTER to go back to the product list...");
            Console.ReadLine();
            Console.Clear();
            AllProducts();
        }
        else
        {
            Console.Clear();
            AllProducts();
        }
    }

    public static void SearchProduct()
    {
        Console.Clear();
        Console.WriteLine("Enter search term:");
        string input = Console.ReadLine();
        var results = storelogic.SearchProducts(input);
        Console.Clear();

        if (results == null || results.Count == 0)
        {
            Console.WriteLine("No products found.");
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
            Console.Clear();
            Start();
            return;
        }

        Console.WriteLine("Results from search\n");
        foreach (var p in results)
        {
            Console.WriteLine($"[{p.ProductId}] {p.ProductName}");
            Console.WriteLine(p.Description);
            Console.WriteLine($"Price: €{p.Price}");
            Console.WriteLine("——————————————————————————————————");
        }

        Console.WriteLine("\nEnter a Product ID to view details, or press ENTER to go back:");
        string? choice = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(choice) && long.TryParse(choice, out long productId))
        {
            ProductModel selected = results.FirstOrDefault(p => p.ProductId == productId);
            if (selected != null)
            {
                ProductDetails(selected);
                return;
            }
        }

        Console.Clear();
        Start();
    }

    public static void ViewBasket()
    {
        Console.Clear();
        var products = basketLogic.GetBasketProducts();

        Console.WriteLine("=== Your Basket ===\n");

        if (products.Count == 0)
        {
            Console.WriteLine("Your basket is empty.");
            Console.WriteLine("\nPress ENTER to go back to the store...");
            Console.ReadLine();
            Console.Clear();
            Start();
            return;
        }

        foreach (var p in products)
        {
            Console.WriteLine($"- {p.ProductName}");
            Console.WriteLine($"  Price: €{p.Price}");
            Console.WriteLine("——————————————————————————————————");
        }
        Console.WriteLine($"\nTotal: €{basketLogic.GetBasketTotal():F2}");

        Console.WriteLine("\n[1] Place Order");
        Console.WriteLine("[2] Back to store");
        string? choice = Console.ReadLine();

        if (choice == "1")
        {
            bestellingLogic.PlaceOrder();
            Console.Clear();
            Console.WriteLine("Your order has been placed successfully!");
            Console.WriteLine("\nPress ENTER to go back to the store...");
            Console.ReadLine();
            Console.Clear();
            Start();
        }
        else
        {
            Console.Clear();
            Start();
        }
    }
}