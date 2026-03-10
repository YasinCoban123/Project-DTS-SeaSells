public class BasketLogic
{
    private BasketAccess _basketAccess = new BasketAccess();
    private StoreAcces _storeAccess = new StoreAcces();

    public void AddProductToBasket(long productId)
    {
        long userId = AccountsLogic.CurrentAccount.UserId;
        _basketAccess.AddToBasket(userId, productId);
    }

    public List<ProductModel> GetBasketProducts()
    {
        long userId = AccountsLogic.CurrentAccount.UserId;
        var basketItems = _basketAccess.GetBasketByUser(userId);
        var allProducts = _storeAccess.GetAllProducts();

        List<ProductModel> products = new List<ProductModel>();
        foreach (var item in basketItems)
        {
            var product = allProducts.FirstOrDefault(p => p.ProductId == item.ProductId);
            if (product != null)
            {
                products.Add(product);
            }
        }
        return products;
    }

    public double GetBasketTotal()
    {
        return GetBasketProducts().Sum(p => p.Price);
    }
}