using FluentValidation.Results;

namespace CleenTeeth.Application.Exceptions;

public class CustomValidationException:Exception
{
    public List<string> ValidationErrors { get; set; } = [];
    public CustomValidationException(ValidationResult validationResult)
    {
        foreach (var validationError in validationResult.Errors)
        {
            ValidationErrors.Add(validationError.ErrorMessage);
        }
    }
}
