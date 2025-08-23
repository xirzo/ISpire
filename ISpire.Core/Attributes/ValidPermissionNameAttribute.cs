using System.ComponentModel.DataAnnotations;
using System.Reflection;
using ISpire.Core.Entities;

namespace ISpire.Core.Attributes;
public class ValidPermissionNameAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        var permissionName = value as string;
        var validNames = typeof(Permissions)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Select(f => f.GetValue(null)?.ToString())
            .ToList();

        if (permissionName != null && validNames.Contains(permissionName))
        {
            return ValidationResult.Success!;
        }

        return new ValidationResult($"Invalid permission name: {permissionName}");
    }
}