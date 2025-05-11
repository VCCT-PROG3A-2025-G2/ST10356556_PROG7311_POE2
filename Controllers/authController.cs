using Microsoft.AspNetCore.Mvc;
using Agri_Energy_Connect.Data;
using Agri_Energy_Connect.Models;
using System.Linq;

namespace Agri_Energy_Connect.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUser(RegistrationModel model)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(model.UserType))
            {
                ViewBag.Error = "Please complete all fields and select a role.";
                return View(model);
            }

            if (model.UserType == "Employee")
            {
                if (_context.Employees.Any(e => e.Email == model.Email))
                {
                    ViewBag.Error = "Employee already exists.";
                    return View(model);
                }

                var employee = new Employee { Email = model.Email, Password = model.Password };
                _context.Employees.Add(employee);
                _context.SaveChanges();
                TempData["Message"] = "Employee account created!";
                return RedirectToAction("EmployeeLogin", "Employee");
            }
            else if (model.UserType == "Farmer")
            {
                if (_context.Farmers.Any(f => f.Email == model.Email)) // ✅ Now using correct field
                {
                    ViewBag.Error = "Farmer already exists.";
                    return View(model);
                }

                var farmer = new Farmer
                {
                    FullName = "New Farmer",
                    Contact = "N/A",
                    Location = "N/A",
                    Email = model.Email
                };

                _context.Farmers.Add(farmer);
                _context.SaveChanges();
                TempData["Message"] = "Farmer account created!";
                return RedirectToAction("FarmerLogin", "Farmer");
            }

            ViewBag.Error = "Invalid role selected.";
            return View(model);
        }
    }
}
