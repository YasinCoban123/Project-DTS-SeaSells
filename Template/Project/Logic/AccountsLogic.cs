

//This class is not static so later on we can use inheritance and interfaces
public class AccountsLogic
{

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself
    public static AccountModel? CurrentAccount { get; private set; }
    private UserAccountsAccess _access = new();

    public AccountsLogic()
    {
        // Could do something here

    }

    public AccountModel CheckLogin(string email, string password)
    {
        AccountModel accountinfo = _access.GetByEmail(email);

        if (password == accountinfo.Password)
        {
            AccountModel acc = _access.GetByEmail(email);
            if (acc != null)
            {
                CurrentAccount = acc;
                return acc;
            }
        }
        return null;
    }



    public AccountModel MakeAccount(string email, string password, string name)
    {
        bool notAdmin = false;
        AccountModel newAccount = new AccountModel(name, email, password, notAdmin);
        _access.Write(newAccount);

        CurrentAccount = newAccount;
        return newAccount;
    }



    public bool CheckPassword(string password)
    {
        if (password.Length < 6)
        {
            return false;
        }
        if (!password.Any(ch => char.IsUpper(ch)))
        {
            return false;
        }
        if (!password.Any(ch => char.IsDigit(ch)))
        {
            return false;
        }
        return true;
    }

    public bool CheckEmailCorrect(string email)
    {
        return email.Contains("@");
    }

    public bool CheckIfEmailExist(string email)
    {
        UserAccountsAccess access = new UserAccountsAccess();
        AccountModel accountinfo = access.GetByEmail(email);

        if (accountinfo is null)
        {
            return true;
        }

        if (email == accountinfo.Email)
        {
            return false;
        }
        return true;
    }

}
