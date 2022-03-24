using CRUD_Product2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CRUD_Product2.Global;
namespace CRUD_Product2.Controllers
{
    public class HomeController : Controller    
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {       
            return View(ListGlobal.products);
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if(ListGlobal.products.Count()>0)
            { int maxId = ListGlobal.products.Count();
                product.Id = maxId;
            }
            else
            {
                product.Id = 0;
            }
            ListGlobal.products.Add(product);
            return Redirect("Index");
        }
        public IActionResult DeleteProduct(int id)
        {
            Product deleteProduct = ListGlobal.products.Find(e => e.Id == id);
            if(deleteProduct != null)
                ListGlobal.products.Remove(deleteProduct);
            return Redirect("Index");
        }
        public IActionResult ViewUpdate(int id)
        {
            Product product = ListGlobal.products.Find(e => e.Id == id);
            return View(product);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            Product updateProduct = ListGlobal.products.Find(e => e.Id == product.Id);
            if (updateProduct != null)
            {
                     updateProduct.Name = product.Name;
                    updateProduct.Price = product.Price;
                    updateProduct.Category = product.Category;
            }    
              
            return Redirect("Index");
        }

    }
  }