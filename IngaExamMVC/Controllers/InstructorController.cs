using Microsoft.AspNetCore.Mvc;

namespace IngaExamMVC.Controllers;

public class InstructorController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}