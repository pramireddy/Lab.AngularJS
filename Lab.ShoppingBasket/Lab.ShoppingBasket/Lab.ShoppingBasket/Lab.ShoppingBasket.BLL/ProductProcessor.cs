using Lab.ShoppingBasket.DAL;
using System.Linq;


namespace Lab.ShoppingBasket.BLL
{
    public class ProductProcessor : IBasketProcessor
    {
        public IBasket Process(IBasket basket)
        {
            basket.Total = basket.Products.Sum(x => x.Price);
            return basket;
        }
    }
}
