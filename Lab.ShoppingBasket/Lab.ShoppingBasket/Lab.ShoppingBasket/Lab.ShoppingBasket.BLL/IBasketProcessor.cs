using Lab.ShoppingBasket.DAL;

namespace Lab.ShoppingBasket.BLL
{
    public interface IBasketProcessor
    {
        IBasket Process(IBasket basket);
    }
}
