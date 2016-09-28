using System.Collections.Generic;

namespace Lab.ShoppingBasket.DAL
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
    }
}
