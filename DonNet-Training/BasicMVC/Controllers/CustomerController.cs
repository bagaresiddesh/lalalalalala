using BasicMVC.Models;
using Microsoft.AspNetCore.Mvc;


namespace BasicMVC.Controllers
{
    [Route("api/Customer")]
    public class CustomerController : Controller
    {
        public static List<Customer> customers = new List<Customer>();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            return View(customers);
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Customer customer)
        {
            customers.Add(customer);
            return RedirectToAction("Get",customers);
        }
    }
}
