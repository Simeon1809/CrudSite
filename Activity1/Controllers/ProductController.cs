using System;
using System.Collections.Generic;
using Activity1.Models;
using Activity1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Activity1.Controllers
{
        
      public class ProductController : Controller
      {
        // ProductsDAO repository;
        HardCodedSampleDataRepository repository;

       //  public IProductDataService repository { get; set; }
        
          public ProductController()
          { 
            repository = new HardCodedSampleDataRepository();
          }
        public IActionResult Index()
        {
            return View(repository.AllProducts());
        }

        public IActionResult SearchResults(string searchTerm)
        {
           // ProductsDAO products = new ProductsDAO();
            List<ProductModel> productList = repository.SearchProducts(searchTerm);

            return View("index", productList);
        }

        public IActionResult SearchForm()
        {
            return View();
        }
 
        public IActionResult CreateForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProcessCreate(ProductModel product)
        {
            repository.Insert(product);
            return View("Index", repository.AllProducts());
        }
        public IActionResult ShowDetails(int Id)
        {
           // ProductsDAO products = new ProductsDAO();
            ProductModel foundProduct = repository.GetProductById(Id);
            return View( foundProduct);
        }

        public IActionResult Edit(int Id)
        {
           // ProductsDAO products = new ProductsDAO();
            ProductModel foundProduct = repository.GetProductById(Id);
            return View("ShowEdit", foundProduct);
        }

        public IActionResult ProcessEdit(ProductModel product)
        {
           // ProductsDAO products = new ProductsDAO();
            repository.Update(product);
            return View("Index", repository.AllProducts());
        }

        public IActionResult ProcessEditReturnPartial(ProductModel product)
        {
            repository.Update(product);
            return PartialView("_productCard", product);
        }
        public IActionResult Delete(int Id)
        { 
            ProductModel DeleteMe = repository.GetProductById(Id);
            repository.Delete(DeleteMe);
            return View("Index", repository.AllProducts());
        }
      }
}
