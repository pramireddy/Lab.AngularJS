using System.Collections.Generic;

namespace Lab.ShoppingBasket.DAL
{
    public interface IOfferVoucherRepository
    {
        IEnumerable<OfferVoucher> GetOffVouchers();
        OfferVoucher GetOffVoucher(int id);
    }
}
