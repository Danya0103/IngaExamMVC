using System.ComponentModel.DataAnnotations;
namespace IngaExamMVC.Models;

public class Instructor
{
    // Id, FirstName, LastName, Email, Department
    
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Будь ласка, заповніть поле: ")]
    [MinLength(2, ErrorMessage = "Будь ласка, дотримуйтесь діапазону символів.")]
    [MaxLength(50, ErrorMessage = "Будь ласка, дотримуйтесь діапазону символів.")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Будь ласка, заповніть поле: ")]
    [MinLength(2, ErrorMessage = "Будь ласка, дотримуйтесь діапазону символів.")]
    [MaxLength(100, ErrorMessage = "Будь ласка, дотримуйтесь діапазону символів.")]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "Будь ласка, заповніть поле: ")]
    [EmailAddress(ErrorMessage = "Будь ласка, дотримуйтесь вимог електронної пошти.")]
    public string Email { get; set; }
    
    public string Departament { get; set; }
    
}