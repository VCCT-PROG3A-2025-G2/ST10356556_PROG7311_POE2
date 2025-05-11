using Microsoft.AspNetCore.Mvc;
using Agri_Energy_Connect.Data;
using Agri_Energy_Connect.Models;

public class EmployeeController : Controller
{
    private readonly ApplicationDbContext _context;

    public EmployeeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult EmployeeLogin()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ValidateEmployeeLogin(string Email, string Password)
    {
        // Replace this with real database validation later
        if (Email == "PlaceHolder@employee.com" && Password == "password")
        {
            return RedirectToAction("EmployeeDashboard");
        }

        ViewBag.Error = "Invalid credentials.";
        return View("EmployeeLogin");
    }

    public IActionResult EmployeeDashboard()
    {
        return View();
    }


    [HttpGet]
    public IActionResult AddFarmer()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddFarmer(Farmer farmer)
    {
        if (ModelState.IsValid)
        {
            _context.Farmers.Add(farmer);
            _context.SaveChanges();
            ViewBag.Message = "Farmer profile successfully added!";
        }

        return View();
    }

    public IActionResult ViewProducts()
    {
        return View();
    }
}
