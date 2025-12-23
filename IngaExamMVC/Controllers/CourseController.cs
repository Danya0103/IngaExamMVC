using Microsoft.AspNetCore.Mvc;

namespace IngaExamMVC.Controllers;

public class CourseController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}