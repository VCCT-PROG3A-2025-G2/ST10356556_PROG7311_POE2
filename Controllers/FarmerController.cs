
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
}
