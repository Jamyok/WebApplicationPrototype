using Microsoft.AspNetCore.Mvc;
using StudentAttributes.Data;
using StudentAttributes.Models;
using System.Linq;

namespace StuCon.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Index
        public IActionResult Index()
        {
            var studentCount = _context.Students.Count();
            ViewBag.StudentCount = studentCount;
            return View();
        }
    }
}