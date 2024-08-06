using System.ComponentModel.DataAnnotations;

namespace BlazorWebAssembly.CustomDataAnnotations;

// This was copied from what I had for AllowedValues, then used ChatGPT to refine it.
public class UnallowedValues(params string[] invalidValues) : ValidationAttribute
{
    private readonly List<string> _unallowedValues = invalidValues.ToList();

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null) return ValidationResult.Success;

        var valueString = value.ToString()!;

        foreach (var invalidValue in _unallowedValues)
        {
            if (valueString.Contains(invalidValue, StringComparison.OrdinalIgnoreCase))
            {
                return new ValidationResult($"The value '{valueString}' is not valid because it contains '{invalidValue}'.");
            }
        }

        return ValidationResult.Success;
    }
}