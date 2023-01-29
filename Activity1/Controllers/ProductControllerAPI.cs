using System.Collections.Generic;
using Activity1.Models;
using Activity1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Activity1.Controllers 
{
    [ApiController]
    [Route("api/productController")]
    public class ProductControllerAPI : ControllerBase
    {
        ProductsDAO repository;

        public ProductControllerAPI()
        {
            repository = new ProductsDAO();
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> Index()
        {
            List<ProductModel> products = repository.AllProducts();

            List<ProductDTO> productDTOs = new List<ProductDTO>();
            foreach(var p in products)
            {
                productDTOs.Add(new ProductDTO(p));
            }
            return productDTOs;
        }

        [HttpGet("searchproduct/{searchTerm}")]
        public ActionResult <IEnumerable<ProductModel>> SearchResults(string searchTerm)
        {
            return repository.SearchProducts(searchTerm);
        } 

        [HttpGet("ShowOneDetail/{id}")]
        public ActionResult <ProductDTO> ShowDetails(int Id)
        {
            ProductModel p = repository.GetProductById(Id);
            ProductDTO pDTO = new ProductDTO(p);
            return pDTO; 
        }

        [HttpPost("CreateProduct")]
        public ActionResult <int> ProcessCreate(ProductModel product)
        {
           int newId = repository.Insert(product);
           return newId;
        }
        
        [HttpPut("updateProduct")]
        public ActionResult <ProductModel> ProcessEdit(ProductModel product)
        {
            repository.Update(product);
            return repository.GetProductById(product.Id);
        }

        [HttpDelete("DeleteOne/{Id}")]
        public ActionResult <bool> Delete(int Id)
        {
            ProductModel deleteMe = repository.GetProductById(Id);
            bool success = repository.Delete(deleteMe);
            return success;
        }
    }
}
