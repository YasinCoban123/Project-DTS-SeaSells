

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


        public bool CheckDob(string dobString)
    {
        // checkt of de dob in format DD-MM-YYYY is
        if (dobString.Length != 10)
        {
            return false;
        }
        if (dobString[2] != '-' || dobString[5] != '-')
        {
            return false;
        }
        string dayString = dobString.Substring(0, 2);
        string monthString = dobString.Substring(3, 2);
        string yearString = dobString.Substring(6, 4);
        if (!int.TryParse(dayString, out int day) ||
            !int.TryParse(monthString, out int month) ||
            !int.TryParse(yearString, out int year))
        {
            return false;
        }
        if (day < 1 || day > 31 || month < 1 || month > 12 || year < 1900 || year > DateTime.Now.Year)
        {
            return false;
        }
        return true;
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
