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

    [HttpGet]
    public IActionResult EmployeeLogin()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ValidateEmployeeLogin(string Email, string Password) //checks entered credentials against employees in database
    {
        var employee = _context.Employees
            .FirstOrDefault(e => e.Email == Email && e.Password == Password);

        if (employee != null)
        {
            HttpContext.Session.SetInt32("EmployeeId", employee.Id);
            HttpContext.Session.SetString("EmployeeEmail", employee.Email);
            return RedirectToAction("EmployeeDashboard");
        }

        ViewBag.Error = "Invalid credentials.";
        return View("EmployeeLogin");
    }


    public IActionResult EmployeeDashboard()  //dislpays employee dashboard
    {
        var farmers = _context.Farmers.ToList();
        return View(farmers);
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear(); 
        return RedirectToAction("Index", "Home"); 
    }


    [HttpGet]
    public IActionResult AddFarmer()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddFarmer(Farmer farmer) //add farmer logic for employee
    {
        if (ModelState.IsValid)
        {
            _context.Farmers.Add(farmer);
            _context.SaveChanges();
            ViewBag.Message = "Farmer profile successfully added!";
        }

        return View();
    }

    public IActionResult ViewProducts(string search, string category, DateTime? fromDate, DateTime? toDate) //gets product details when requested by employee
    {
        var query = _context.Products.AsQueryable();

        if (!string.IsNullOrEmpty(search))
            query = query.Where(p => p.ProductName.Contains(search));

        if (!string.IsNullOrEmpty(category))
            query = query.Where(p => p.Category == category);

        if (fromDate.HasValue)
            query = query.Where(p => p.ProductionDate >= fromDate.Value);

        if (toDate.HasValue)
            query = query.Where(p => p.ProductionDate <= toDate.Value);

        var products = query.ToList();
        return View(products);
    }
}

