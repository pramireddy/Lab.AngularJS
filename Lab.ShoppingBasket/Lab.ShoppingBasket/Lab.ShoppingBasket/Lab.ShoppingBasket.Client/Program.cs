using Lab.ShoppingBasket.BLL;
using Lab.ShoppingBasket.Service;
using Lab.ShoppingBasket.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab.ShoppingBasket.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IProductRepository productRepository = new ProductRepository();
            IGiftVoucherRepository giftVoucherRepository = new GiftVoucherRepository();
            IOfferVoucherRepository offerVoucherRepository = new OfferVoucherRepository();

            // Empty Basket
            var basket = new Basket
            {
                Products = new List<Product>()
            };

            IBasketProcessorFactory basketProcessorFactory = new BasketProcessorFactory();
            var basetService = new BasketService(basketProcessorFactory);
            var basketServiceResponse = basetService.GetBasketTotal(basket);

            Console.WriteLine($"Basket0 - Total : £{basketServiceResponse.BasketValue}");
            Console.WriteLine($"Basket0 - Message:{basketServiceResponse.Notifications.ToList().FirstOrDefault()}");

            // Basket 1:
            basket = new Basket
            {
                GiftVouchers = new List<GiftVoucher>
                {
                    giftVoucherRepository.GetGiftVoucher(1)
                },
                
                Products = new List<Product>
                {
                    productRepository.GetProduct(1),
                    productRepository.GetProduct(2)
                }

            };

            basetService = new BasketService(basketProcessorFactory);
            basketServiceResponse = basetService.GetBasketTotal(basket);

            Console.WriteLine( $"Basket1 - Total : £{basketServiceResponse.BasketValue}");

            // Basket 2:

            basket = new Basket
            {
                Products = new List<Product>
                {
                    productRepository.GetProduct(3),
                    productRepository.GetProduct(4)
                },                
                OfferVoucher =  offerVoucherRepository.GetOffVoucher(1)
            };

            basketProcessorFactory = new BasketProcessorFactory();
            basetService = new BasketService(basketProcessorFactory);
            basketServiceResponse = basetService.GetBasketTotal(basket);

            Console.WriteLine($"Basket2 - Total : £{basketServiceResponse.BasketValue}");
            Console.WriteLine($"Basket2 - Message:{basketServiceResponse.Notifications.ToList().FirstOrDefault()}");

            // Basket 3:

            basket = new Basket
            {
                Products = new List<Product>
                {
                    productRepository.GetProduct(3),
                    productRepository.GetProduct(4),
                    productRepository.GetProduct(5)
                },
             OfferVoucher = offerVoucherRepository.GetOffVoucher(1)
            };

            basketProcessorFactory = new BasketProcessorFactory();
            basetService = new BasketService(basketProcessorFactory);
            basketServiceResponse = basetService.GetBasketTotal(basket);

            Console.WriteLine($"Basket3 - Total : £{basketServiceResponse.BasketValue}");
            Console.WriteLine($"Basket3 - Message:{basketServiceResponse.Notifications.ToList().FirstOrDefault()}");

            // Basket 4:

            basket = new Basket
            {
                Products = new List<Product>
                {
                    productRepository.GetProduct(3),
                    productRepository.GetProduct(4)
                },
                GiftVouchers = new List<GiftVoucher>
                {
                    giftVoucherRepository.GetGiftVoucher(1)
                },
                OfferVoucher = offerVoucherRepository.GetOffVoucher(2)
            };

            basketProcessorFactory = new BasketProcessorFactory();
            basetService = new BasketService(basketProcessorFactory);
            basketServiceResponse = basetService.GetBasketTotal(basket);

            Console.WriteLine($"Basket4 - Total : £{basketServiceResponse.BasketValue}");
            Console.WriteLine($"Basket4 - Message:{basketServiceResponse.Notifications.ToList().FirstOrDefault()}");

            // Basket 5:

            basket = new Basket
            {
                Products = new List<Product>
                {
                    productRepository.GetProduct(3),
                    productRepository.GetProduct(6)
                },
                OfferVoucher = offerVoucherRepository.GetOffVoucher(2)
            };

            basketProcessorFactory = new BasketProcessorFactory();
            basetService = new BasketService(basketProcessorFactory);
            basketServiceResponse = basetService.GetBasketTotal(basket);

            Console.WriteLine($"Basket5 - Total : £{basketServiceResponse.BasketValue}");
            Console.WriteLine($"Basket5 - Message:{basketServiceResponse.Notifications.ToList().FirstOrDefault()}");

            Console.ReadLine();

        }
    }
}
