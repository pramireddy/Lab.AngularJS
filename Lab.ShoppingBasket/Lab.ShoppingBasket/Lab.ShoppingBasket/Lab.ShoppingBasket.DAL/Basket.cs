using System.Collections.Generic;

namespace Lab.ShoppingBasket.DAL
{
    public class Basket : IBasket
    {
        public Basket()
        {
            Messages = new List<string>();
        }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<GiftVoucher> GiftVouchers { get; set; }
        public OfferVoucher OfferVoucher { get; set; }
        public IList<string> Messages { get; set; }
        public decimal Total { get; set; }
    }
}
