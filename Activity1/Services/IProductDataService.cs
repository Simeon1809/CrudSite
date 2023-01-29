using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Activity1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Activity1.Services
{
    interface IProductDataService
    {
        List<ProductModel> AllProducts();
        List<ProductModel> SearchProducts(string searchTerm);
        ProductModel GetProductById(int Id);
    
        int Insert(ProductModel product); 
        bool Delete(ProductModel product);
        int Update(ProductModel product);

    }
    
}
