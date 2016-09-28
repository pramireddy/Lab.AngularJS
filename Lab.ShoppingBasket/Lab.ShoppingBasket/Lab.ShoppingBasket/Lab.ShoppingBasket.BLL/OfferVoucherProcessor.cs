using Lab.ShoppingBasket.DAL;
using Lab.ShoppingBasket.Utilities.Enumerations.Voucher;
using System.Linq;
using Lab.ShoppingBasket.Utilities.Enumerations.Product;


namespace Lab.ShoppingBasket.BLL
{
    public class OfferVoucherProcessor : IBasketProcessor
    {
        private bool _isOfferApplied;

        public IBasket Process(IBasket basket)
        {
            if (basket.OfferVoucher == null)
                return basket;

            basket = ValidateOfferVoucherForThreshold(basket);
            if(!BasketHasErrors(basket) && basket.OfferVoucher.OfferVoucherType == OfferVoucherType.Basket)
            {
                basket.Total = basket.Total - basket.OfferVoucher.Value;
                _isOfferApplied = true;
            }

            if (!BasketHasErrors(basket) && !_isOfferApplied && basket.OfferVoucher.OfferVoucherType == OfferVoucherType.Product)
            {
                basket.Total = ValidateOfferVoucherForProducts(basket).Total;
            }

            if(!BasketHasErrors(basket) && !_isOfferApplied)
            {
                basket.Messages.Add($"There are no products in your basket applicable to voucher Voucher {basket.OfferVoucher.Code}.");
            }

            return basket;
        }

        private static IBasket ValidateOfferVoucherForThreshold(IBasket basket)
        {
            
            var basketsTotal = basket.Products.Where(x=>x.Category != Category.GiftVoucher).Sum(x => x.Price);

            if (basketsTotal < basket.OfferVoucher.Threshold)
            {
                var additonalAmountToSpend = basket.OfferVoucher.Threshold - basketsTotal + 0.01m;
                basket.Messages.Add($"You have not reached the spend threshold for voucher {basket.OfferVoucher.Code}. Spend another £{additonalAmountToSpend} to receive £5.00 discount from your basket total.");
                basketsTotal = basket.Total;
            }

            basket.Total = basketsTotal;

            return basket;
        }

        private IBasket ValidateOfferVoucherForProducts(IBasket basket)
        {
            var basketsTotal = 0.00m;
            foreach (var product in basket.Products)
            {
                if(product.Category == basket.OfferVoucher.ProductCategory && !_isOfferApplied)
                {
                    _isOfferApplied = true;
                    var productPrice = product.Price;
                    productPrice -= basket.OfferVoucher.Value;
                    productPrice = productPrice >= 0 ? productPrice : 0m;

                    basketsTotal += productPrice;
                }
                else
                {
                    basketsTotal += product.Price;
                }
            }

            basket.Total = basketsTotal;
            return basket;
        }

        private static bool BasketHasErrors(IBasket basket)
        {
            return basket.Messages.Count > 0;
        }
    }
}
