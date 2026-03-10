public class ProductLogic
{
    private ProductAccess _access = new();

    public List<ProductModel> AllProducts()
    {
        return _access.GetAllProducts();
    }

    public void AddAProduct(ProductModel product)
    {
        _access.Write(product);
    }
}