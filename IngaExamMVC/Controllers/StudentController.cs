using Microsoft.AspNetCore.Mvc;

namespace IngaExamMVC.Controllers;

public class StudentController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}