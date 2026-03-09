public class BestellingLogic
{
    private BestellingAccess _access = new();

    public List<BestellingModel> AllOrders()
    {
        return _access.GetAllOrders();
    }
}