public class BestellingLogic
{
    private BestellingAccess _access = new();

    public List<BestellingModel> AllOrders()
    {
        return _access.GetAllOrders();
    }

    public void Delete(BestellingModel bestelling)
    {
        _access.Delete(bestelling);
    }
}