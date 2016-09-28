using System.Collections.Generic;
using Lab.ShoppingBasket.BLL;
using NUnit.Framework;
using Lab.ShoppingBasket.DAL;

namespace Lab.ShoppingBasket.BLLTest
{
    [TestFixture]
    public class ProductProcessorTest
    {
        private IProductRepository _productRepository;
  
        [OneTimeSetUp]
        public void TestSetup()
        {
            _productRepository = new ProductRepository();
        }

        [Test]
        public void Test_Products_TotalPrice()
        {
            // arrange 
            var baset = new Basket
            {
                Products = new List<Product>
                {
                    _productRepository.GetProduct(1),
                    _productRepository.GetProduct(2)
                }

            };

            var productProcessor = new ProductProcessor();

            // act
            productProcessor.Process(baset);

            // assert
            Assert.AreEqual(65.15, baset.Total);
        }
    }
}
