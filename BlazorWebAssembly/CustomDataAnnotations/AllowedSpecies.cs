namespace BlazorWebAssembly.CustomDataAnnotations;

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

public class AllowedSpecies : ValidationAttribute
{
    private readonly string[] _allowedSpecies;

    public AllowedSpecies(params string[] allowedSpecies)
    {
        _allowedSpecies = allowedSpecies;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null || _allowedSpecies.Contains(value.ToString()))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("The species entered is not one of our verified options.");
    }
}