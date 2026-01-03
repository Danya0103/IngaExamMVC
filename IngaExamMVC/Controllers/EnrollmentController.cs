using Microsoft.AspNetCore.Mvc;
using IngaExamMVC.Data;
using IngaExamMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IngaExamMVC.Controllers;

public class EnrollmentController : Controller
{
    private readonly UniversityContext _context;

    public EnrollmentController(UniversityContext context)
    {
        _context = context;
    }
    
    // GET
    public IActionResult Create()
    {
        ViewBag.Students = new SelectList(_context.Students, "Id", "Email");
        ViewBag.Courses = new SelectList(_context.Courses, "Id", "Title");
        return View();
    }
    
    // POST
    [HttpPost]
    public IActionResult Create(Enrollment enrollment)
    {
        //if (ModelState.IsValid)
        //{
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
            
            return RedirectToAction("Index", "Course");
        //}

        //return View(enrollment);
    }
}