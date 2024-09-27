using Microsoft.AspNetCore.Mvc;
using FinancialProgram.Models;
using FinancialProgram.Data;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FinancialProgram.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(); // Landing page
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(); // Registration view
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // Hash password before saving (implement secure hashing in production)
                user.PasswordHash = HashPassword(user.PasswordHash);
                
                _context.Users.Add(user);  // Add user to the context
                _context.SaveChanges();     // Save changes to the database
                return RedirectToAction("Login"); // Redirect to login after successful registration
            }
            return View(user); // Return to registration view if model state is invalid
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(); // Login view
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Find user by username and verify password
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user != null && VerifyPassword(password, user.PasswordHash))
            {
                HttpContext.Session.SetInt32("UserId", user.UserId); // Store user ID in session
                return RedirectToAction("Dashboard"); // Redirect to dashboard
            }
            ModelState.AddModelError("", "Invalid login attempt."); // Add error for invalid login
            return View(); // Return to login view
        }

        public IActionResult Dashboard()
        {
            // Implement logic to show surveys for the logged-in user
            return View(); // Return dashboard view
        }

        private string HashPassword(string password)
        {
            // Simple hashing (for demo purposes only; use a stronger hashing algorithm in production)
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            // Verify if the entered password matches the hashed password
            var hashedInput = HashPassword(password);
            return hashedInput == hashedPassword;
        }
    }
}
