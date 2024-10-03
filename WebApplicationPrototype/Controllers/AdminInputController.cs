using Microsoft.AspNetCore.Mvc;
using AdminUser.Models;

namespace AdminUser.Controllers
{
    public class AdminInputController : Controller
    {
        // GET: Display the form
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST: Handle form submission
        [HttpPost]
        public IActionResult Submit(AdminInputFormModel model)
        {
            if (ModelState.IsValid)
            {
                // Process the form (e.g., save to database)
                
                // Redirect to a confirmation page or display a success message
                return RedirectToAction("Success");
            }
            
            // If the model state is invalid, return to the form with validation messages
            return View("Index", model);
        }

        // GET: Success page after form submission
        public IActionResult Success()
        {
            return View();
        }
    }
}