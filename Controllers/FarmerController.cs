
using Microsoft.AspNetCore.Mvc;
using Agri_Energy_Connect.Data;
using Agri_Energy_Connect.Models; 
using System;
using System.Linq;
public class FarmerController : Controller
{
    private readonly ApplicationDbContext _context;

    public FarmerController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult FarmerLogin()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ValidateFarmerLogin(string Email, string Password)
    {
        var farmer = _context.Farmers
            .FirstOrDefault(f => f.Email == Email && f.Password == Password);

        if (farmer != null)
        {
            // Login successful — optionally store in session
            HttpContext.Session.SetInt32("FarmerId", farmer.Id);
            HttpContext.Session.SetString("FarmerEmail", farmer.Email);

            return RedirectToAction("FarmerDashboard");
        }

        ViewBag.Error = "Invalid email or password.";
        return View("FarmerLogin");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear(); 
        return RedirectToAction("Index", "Home");
    }

    public IActionResult FarmerDashboard()
    {
        return View();
    }

    [HttpGet]
    public IActionResult AddProduct()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        var farmerId = HttpContext.Session.GetInt32("FarmerId");
        if (farmerId == null)
        {
            return RedirectToAction("FarmerLogin");
        }

        if (ModelState.IsValid)
        {
            product.FarmerId = farmerId.Value; 
            _context.Products.Add(product);
            _context.SaveChanges();
            ViewBag.Message = "Product submitted successfully!";
        }

        return View();
    }



    public IActionResult ViewProducts()
    {
        var farmerId = HttpContext.Session.GetInt32("FarmerId");
        if (farmerId == null)
        {
            return RedirectToAction("FarmerLogin");
        }

        var products = _context.Products
            .Where(p => p.FarmerId == farmerId.Value)
            .ToList();

        return View(products);
    }


    [HttpGet]
    public IActionResult RegisterFarmer()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RegisterFarmer(FarmerRegistrationModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Error = "Please fill in all fields.";
            return View(model);
        }

        var existingFarmer = _context.Farmers.FirstOrDefault(f => f.Email == model.Email);

        if (existingFarmer != null)
        {
            
            existingFarmer.Password = model.Password;
            _context.SaveChanges();

            TempData["Message"] = "Account completed! Please log in.";
            return RedirectToAction("FarmerLogin");
        }

        ViewBag.Error = "No farmer account found with that email. Please contact support or your assigned employee.";
        return View(model);
    }

}
