using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Activity1.Models;
using Bogus;


namespace Activity1.Services
{
    public class HardCodedSampleDataRepository : IProductDataService
    {
       static List<ProductModel> productsList = new List<ProductModel>();
        public bool Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> AllProducts()
        {
            if (productsList.Count == 0) { 

                productsList.Add(new ProductModel { Id = 1, Name = "mouse-pad", Price = 5.99m, Description = "Asquare piece of plastic to make moussing easier" });
                productsList.Add(new ProductModel { Id = 2, Name = "mango", Price = 15.99m, Description = "Asquare piece of plastic to make moussing easier" });
                productsList.Add(new ProductModel { Id = 3, Name = "Game-pad", Price = 510.99m, Description = "Asquare piece of plastic to make moussing easier" });
                productsList.Add(new ProductModel { Id = 4, Name = "phone", Price = 50.99m, Description = "Asquare piece of plastic to make moussing easier" });

                for (int i = 0; i < 100; i++)
                {
                    productsList.Add(new Faker<ProductModel>()
                        .RuleFor(p => p.Id, i + 5)
                        .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                        .RuleFor(p => p.Price, f => f.Random.Decimal(100))
                        .RuleFor(p => p.Description, f => f.Rant.Review())
                        );
                }

            }
            return productsList;
        }

        public ProductModel GetProductById(int Id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
