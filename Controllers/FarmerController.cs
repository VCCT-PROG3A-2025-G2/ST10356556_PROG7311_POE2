
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
        // Replace with real DB logic later
        if (Email == "PlaceHolder@farmer.com" && Password == "password")
            return RedirectToAction("FarmerDashboard");

        ViewBag.Error = "Invalid credentials.";
        return View("FarmerLogin");
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
        if (ModelState.IsValid)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            ViewBag.Message = "Product submitted successfully!";
        }

        return View();
    }


    public IActionResult ViewFarmerProducts()
    {
        var products = _context.Products.ToList();
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
