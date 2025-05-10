using Agri_Energy_Connect.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Agri_Energy_Connect.Controllers
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
            return View();
        }

        

        public IActionResult EmployeeLogin()
        {
            return View();
        }


        public IActionResult FarmerLogin()
        {
            return View();
        }

      
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
