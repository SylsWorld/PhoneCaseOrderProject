using System.ComponentModel.DataAnnotations;
using BlazorWebAssembly.CustomDataAnnotations;

namespace BlazorWebAssembly.Models;

public class PhoneCase
{
    [Required(ErrorMessage = "You must have a phone Brand")]
    [MinLength(1)]
    [MaxLength(25, ErrorMessage = "Brand cannot exceed 25 characters in length")]
    [AllowedValues(["Samsung", "Google", "Nokia", "Motorola", "BlackBerry", "Sony", "Lg", "Razer"])]
    public string Brand { get; set; }
    
    [Required(ErrorMessage = "You must have a phone Model")]
    [MinLength(1)]
    [MaxLength(25, ErrorMessage = "Model cannot exceed 25 characters in length")]
    [UnallowedValues(["iPhone"])]
    public string Model { get; set; }
    
    [Required(ErrorMessage = "You must have a Material")]
    [MinLength(1)]
    [MaxLength(30, ErrorMessage = "Material cannot exceed 30 characters in length")]
    [AllowedValues(["Silicone", "Plastic", "Leather", "Metal", "Rubber", "Wood", "TPU", "Carbon Fiber", "Tungsten Steel", "ABS", "Titanium", "Sheet Metal", "Clam Shell", "Faux Animal Fur", "Appleskin"])]
    public string Material { get; set; }
    
    [Required(ErrorMessage = "You must provide a Cost")]
    [Range(1, 850, ErrorMessage = "Cost must be greater than $0 and less than $850")]
    public decimal Cost { get; set; }
    
    [Required(ErrorMessage = "You must have a Trim color")]
    [MinLength(1)]
    [MaxLength(30, ErrorMessage = "Trim color cannot exceed 30 characters in length")]
    [UnallowedValues(["Yellow"])]
    public string TrimColor { get; set; }
    
    [Required(ErrorMessage = "You must have an Accent color")]
    [MinLength(1)]
    [MaxLength(30, ErrorMessage = "Accent color cannot exceed 30 characters in length")]
    [AllowedValues(["Blue", "Pink", "Yellow","Green", "Greener", "Yellowish", "Blueberry"])]
    public string AccentColor { get; set; }
}