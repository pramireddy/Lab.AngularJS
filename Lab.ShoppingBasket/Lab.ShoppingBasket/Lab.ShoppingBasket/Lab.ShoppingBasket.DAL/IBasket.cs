using System.Collections.Generic;

namespace Lab.ShoppingBasket.DAL
{
    public interface IBasket
    {
        IEnumerable<Product> Products { get; set; }
        IEnumerable<GiftVoucher> GiftVouchers { get; set; }
        OfferVoucher OfferVoucher { get; set; }
        IList<string> Messages { get; set; }
        decimal Total { get; set; }
    }
}
