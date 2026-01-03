using Microsoft.AspNetCore.Mvc;
using IngaExamMVC.Data;
using IngaExamMVC.Models;
using IngaExamMVC.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace IngaExamMVC.Controllers;

public class CourseController : Controller
{
    private readonly UniversityContext _context;
    
    public CourseController(UniversityContext context)
    {
        _context = context;
    }
    
    /* // GET
    public IActionResult Index()
    {
        return View();
    }
    */
    
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
    
    
    public IActionResult Info(int id)
    {
        var course = _context.Courses
            .Include(c => c.Enrollments)
            .ThenInclude(e => e.Student)
            .FirstOrDefault(c => c.Id == id);

        if (course == null) return NotFound();
        return View(course);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(Course course)
    {
        // if (!ModelState.IsValid) return View(course);

        _context.Courses.Add(course);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var course = _context.Courses.Find(id);
        if (course == null) return NotFound();
        return View(course);
    }

    [HttpPost]
    public IActionResult Edit(Course course)
    {
       // if (!ModelState.IsValid) return View(course);

        _context.Update(course);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var course = _context.Courses.Find(id);
        if (course == null) return NotFound();
        return View(course);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var course = _context.Courses.Find(id);
        _context.Courses.Remove(course);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}