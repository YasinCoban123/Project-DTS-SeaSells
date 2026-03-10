public class StoreLogic
{
    private StoreAcces storeAcces = new StoreAcces();

    public List<ProductModel> GetAllProducts()
    {
        return storeAcces.GetAllProducts();
    }

    public List<ProductModel> SearchProducts(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return new List<ProductModel>();
        }

        List<string> words = input.Split(" ").ToList();

        return storeAcces.SearchProducts(words);
    }
}