using Microsoft.AspNetCore.Mvc;
using IngaExamMVC.Data;
using IngaExamMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace IngaExamMVC.Controllers;

public class StudentController : Controller
{
    private readonly UniversityContext _context;

    public StudentController(UniversityContext context)
    {
        _context = context;
    }
    
    // GET
    // public IActionResult Index()
    // {
        // return View();
    // }
    
    // // POST 
    public IActionResult Index(string search)
    {
        var students = _context.Students.AsQueryable();
        if (!string.IsNullOrEmpty(search))
        {
            students = students.Where(s => s.FirstName.Contains(search) || s.Email.Contains(search));
        }
    
        return View(students.ToList());
    }
    
    public IActionResult Info(int id)
    {
        var student = _context.Students
            .Include(s => s.Enrollments)
            .ThenInclude(e => e.Course)
            .FirstOrDefault(s => s.Id == id);

        if (student == null) return NotFound();
        return View(student);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(Student student)
    {
        //if (!ModelState.IsValid) return View(student);

        _context.Students.Add(student);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var student = _context.Students.Find(id);
        if (student == null) return NotFound();
        return View(student);
    }

    [HttpPost]
    public IActionResult Edit(Student student)
    {
       // if (!ModelState.IsValid) return View(student);

        _context.Update(student);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var student = _context.Students.Find(id);
        if (student == null) return NotFound();
        return View(student);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var student = _context.Students.Find(id);
        _context.Students.Remove(student);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}