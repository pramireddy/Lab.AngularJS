using Lab.ShoppingBasket.DAL;
using System.Linq;

namespace Lab.ShoppingBasket.BLL
{
    public class GiftVoucherProcessor : IBasketProcessor
    {
        public IBasket Process(IBasket basket)
        {
            if(basket.GiftVouchers != null && basket.GiftVouchers.Any())
                 basket.Total -= basket.GiftVouchers.Sum(x => x.Value);
            return basket;
        }
    }
}
