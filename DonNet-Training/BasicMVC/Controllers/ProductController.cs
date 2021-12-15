using BasicMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicMVC.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> Products = new List<Product>();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Get()
        {
            return View(Products);
        }
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Product product)
        {
            Products.Add(product);
            return RedirectToAction("Get", Products);
        }

        [HttpGet]
        [Route("Edit")]
        public IActionResult Edit(int id)
        {
            Product product = Products.Where(p => p.Id.Equals(id)).Select(s => s).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(Product product)
        {
            Product originalProduct = Products.Where(p => p.Id.Equals(product.Id)).Select(s => s).FirstOrDefault();
            if(originalProduct!= null)
            {
                originalProduct.Name = product.Name;
                originalProduct.ExpirationDate = product.ExpirationDate;
            };

            return RedirectToAction("Get", Products);
        }
    }
}
