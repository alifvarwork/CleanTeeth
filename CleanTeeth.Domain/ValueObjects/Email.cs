using CleanTeeth.Domain.Exceptions;

namespace CleanTeeth.Domain.ValueObjects;

public record Email
{
    public string Value { get;} = string.Empty;
    public Email(string email)
    {        
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new BussinessRuleException("Patient email cannot be empty.");
        }

        if (!email.Contains("@"))
        {
            throw new BussinessRuleException("Patient email must be a valid email address.");
        }

        Value = email;
    }
}
