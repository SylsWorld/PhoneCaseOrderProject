using System.ComponentModel.DataAnnotations;

namespace BlazorWebAssembly.CustomDataAnnotations;

// This part was started by me, then finished by ChatGPT
public class AllowedValues(params string[] validValues) : ValidationAttribute
{
    private readonly List<string> _allowedValues = validValues.ToList();

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null || _allowedValues.Contains(value.ToString()!))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult($"The value '{value}' is not valid. Allowed values are: {string.Join(", ", _allowedValues)}.");
    }
}