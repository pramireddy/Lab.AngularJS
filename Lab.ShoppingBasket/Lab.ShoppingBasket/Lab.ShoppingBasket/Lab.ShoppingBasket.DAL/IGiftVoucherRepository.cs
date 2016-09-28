using System.Collections.Generic;

namespace Lab.ShoppingBasket.DAL
{
    public interface IGiftVoucherRepository
    {
        IEnumerable<GiftVoucher> GetGiftVouchers();
        GiftVoucher GetGiftVoucher(int id);
    }
}
