using System.ComponentModel.DataAnnotations;
using BlazorWebAssembly.CustomDataAnnotations;

namespace BlazorWebAssembly.Models;

public class Fossil
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    
    [Required]
    // [AllowedSpecies(["Tyrannosaurus", "Triceratops", "Velociraptor"])]
    public string? Species { get; set; }
    
    [Required]
    [Range(1, 70, ErrorMessage = "Age must be greater than 0 and less than 70")]
    public int Age { get; set; }
    
    [Required]
    public string Location { get; set; }
    
    [Required]
    public string Description { get; set; }
}
