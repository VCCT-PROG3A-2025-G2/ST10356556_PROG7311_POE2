using Microsoft.AspNetCore.Mvc;

public class EmployeeController : Controller
{
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


    [HttpPost]
    public IActionResult AddFarmer(string FullName, string Location, string Contact)
    {
        // Save farmer info to DB in the future
        ViewBag.Message = "Farmer profile successfully added!";
        return View();
    }

    public IActionResult ViewProducts()
    {
        return View();
    }
}
