using Microsoft.AspNetCore.Mvc;
using IngaExamMVC.Data;
using IngaExamMVC.Models;

namespace IngaExamMVC.Controllers;

public class StudentController : Controller
{
    private readonly UniversityContext _context;

    public StudentController(UniversityContext context)
    {
        _context = context;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    // POST 
    public IActionResult Index(string search)
    {
        var students = _context.Students.AsQueryable();
        if (!string.IsNullOrEmpty(search))
        {
            students = students.Where(s => s.FirstName.Contains(search) || s.Email.Contains(search));
        }

        return View(students.ToList());
    }
}