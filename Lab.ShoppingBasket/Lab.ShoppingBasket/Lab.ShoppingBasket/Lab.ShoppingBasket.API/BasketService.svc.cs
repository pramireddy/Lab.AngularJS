using System;
using System.Collections.Generic;
using System.Linq;
using Lab.ShoppingBasket.DAL;
using Lab.ShoppingBasket.Service;
using Lab.ShoppingBasket.BLL;

namespace Lab.ShoppingBasket.API
{

    public class BasketService : IBasketService
    {
        private IList<IBasketProcessor> _basketProcessors;
        private readonly IBasketProcessorFactory _basketProcessorFactory;

        public BasketService(IBasketProcessorFactory basketProcessorFactory)
        {
            _basketProcessorFactory = basketProcessorFactory;
        }

        public BasketServiceResponse GetBasketTotal(IBasket basket)
        {
            try
            {
                if (basket.Products == null || !basket.Products.Any())
                    return new BasketServiceResponse()
                    {
                        Notifications = new List<string> { "Your shopping basket is empty" },
                        Success = true,
                        BasketValue = 0.0m
                    };

                _basketProcessors = CreateBasketProcessors();

                foreach (var processor in _basketProcessors)
                {
                    processor.Process(basket);
                }

                return new BasketServiceResponse
                {
                    Notifications = basket.Messages?.ToList(),
                    BasketValue = basket.Total,
                    Success = true
                };
            }
            catch (Exception exception)
            {
                return new BasketServiceResponse
                {
                    ErrorMessage = $"Failed to calculate basket total {exception.Message}",
                    Success = false,
                    BasketValue = 0.0m
                };
            }
        }

        private IList<IBasketProcessor> CreateBasketProcessors()
        {
            return new List<IBasketProcessor>
            {
               _basketProcessorFactory.CreateProductProcessor(),
               _basketProcessorFactory.CreateOfferVoucherProcessor(),
               _basketProcessorFactory.CreateGiftVoucherProcessor()
            };
        }
    }
}
