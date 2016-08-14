using Lab.AngularJSWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Lab.AngularJSWebApi.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M },
            new Product { Id = 4, Name = "Test-4", Category = "Groceries", Price = 1 },
            new Product { Id = 5, Name = "Test-5", Category = "Toys", Price = 3.75M },
            new Product { Id = 6, Name = "Test-6", Category = "Hardware", Price = 16.99M }
        };

        // GET: api/Products
        [ResponseType(typeof(Product))]
        public IEnumerable<Product> Get()
        {
            return products;
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult Get(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if(product ==null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/Products
        public void Post([FromBody]Product product)
        {
            var p = product;
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]Product product,int Id,string cat)
        {
            var p = product;
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
