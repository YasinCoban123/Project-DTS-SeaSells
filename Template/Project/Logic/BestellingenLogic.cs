public class BestellingLogic
{
    private BestellingAccess _access = new();
    private BasketAccess _basketAccess = new();

    public List<BestellingModel> AllOrders()
    {
        return _access.GetAllOrders();
    }

    public List<BestellingModel> GetMyOrders()
    {
        long userId = AccountsLogic.CurrentAccount.UserId;
        return _access.GetOrdersByUser(userId);
    }

    public void PlaceOrder()
    {
        long userId = AccountsLogic.CurrentAccount.UserId;
        var basketItems = _basketAccess.GetBasketByUser(userId);

        foreach (var item in basketItems)
        {
            BestellingModel bestelling = new BestellingModel
            {
                UserId = item.UserId,
                ProductId = item.ProductId
            };
            _access.Write(bestelling);
        }

        _basketAccess.ClearBasket(userId);
    }

    public void Delete(BestellingModel bestelling)
    {
        _access.Delete(bestelling);
    }
}