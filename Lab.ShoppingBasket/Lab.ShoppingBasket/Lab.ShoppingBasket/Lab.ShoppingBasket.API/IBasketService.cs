using Lab.ShoppingBasket.DAL;
using Lab.ShoppingBasket.Service;
using System.ServiceModel;

namespace Lab.ShoppingBasket.API
{
    
    [ServiceContract]
    public interface IBasketService
    {
        [OperationContract]
        BasketServiceResponse GetBasketTotal(IBasket basket);

    }

}
