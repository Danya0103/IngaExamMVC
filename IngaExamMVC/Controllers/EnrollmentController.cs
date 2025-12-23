using Microsoft.AspNetCore.Mvc;

namespace IngaExamMVC.Controllers;

public class EnrollmentController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}