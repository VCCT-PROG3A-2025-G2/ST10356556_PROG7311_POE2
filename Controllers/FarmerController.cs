using Microsoft.AspNetCore.Mvc;

public class FarmerController : Controller
{
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

    public IActionResult AddProduct()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddProduct(string ProductName, string Category, DateTime ProductionDate)
    {
        // Save to DB later
        ViewBag.Message = "Product submitted successfully!";
        return View();
    }
}
