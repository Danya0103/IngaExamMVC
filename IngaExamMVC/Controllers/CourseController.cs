using Microsoft.AspNetCore.Mvc;
using IngaExamMVC.Data;
using IngaExamMVC.Models;
using IngaExamMVC.ViewModels;

namespace IngaExamMVC.Controllers;

public class CourseController : Controller
{
    private readonly UniversityContext _context;
    
    public CourseController(UniversityContext context)
    {
        _context = context;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    // POST
    public IActionResult Index(string instructorName, int? minStudents)
    {
        var cources = _context.Courses.Select(c => new CourseViewModel
        {
            Id = c.Id,
            CourseName = c.Title,
            StudentCount = c.Enrollments.Count
        });

        if (!string.IsNullOrEmpty(instructorName))
        {
            cources = cources.Where(c => c.InstructorName.Contains(instructorName));
        }

        if (minStudents.HasValue)
        {
            cources = cources.Where(c => c.StudentCount >= minStudents);
        }

        return View(cources.ToList());
    }
}