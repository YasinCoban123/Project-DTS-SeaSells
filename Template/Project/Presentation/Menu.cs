static class Menu
{

    //This shows the menu. You can call back to this method to show the menu again
    //after another presentation method is completed.
    //You could edit this to show different menus depending on the user's role
    static public void Start()
    {
        AccountModel ?currentUser = AccountsLogic.CurrentAccount;
        while (true)
        {
            Console.WriteLine($"Welcome to the Main Menu {currentUser.Name}");
            Console.WriteLine($"[1]Account");
            Console.WriteLine($"[2]Store");
            Console.WriteLine($"[3]Orders");
            Console.WriteLine($"[4]Logout");
            Console.WriteLine($"[5]Quit");

            string answer = Console.ReadLine().ToLower();

            if (answer == "1")
            {
                // Store.Start();
            }
            else if (answer == "2")
            {
                Store.Start();
            }
            else if (answer == "3")
            {
                // Reservations.Start();
            }
            else if (answer == "4")
            {
                UserLogin.Start();
            }
            else if (answer == "5")
            {
                Environment.Exit(0);
            }
        }
    }
}