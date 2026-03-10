public class AccountModel
{

    public Int64 UserId { get; set; }
    public string Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
    public bool IsAdmin { get; set; }

    public AccountModel(){ }


    public AccountModel(string name, string email, string password, bool isadmin)
    {
        Name = name;
        Email = email;
        Password = password;
        IsAdmin = isadmin;
    }

}



