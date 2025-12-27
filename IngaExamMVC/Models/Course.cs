using System.ComponentModel.DataAnnotations;
namespace IngaExamMVC.Models;

public class Course
{
    // Id, Title, Description, Credits
    
    public int Id { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    [Required]
    [Range(1, 100)]
    public int Credits { get; set; }
    
    public ICollection<Enrollment> Enrollments { get; set; }
}