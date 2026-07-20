using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Domain.Entities;

public class Dentist
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public Email Email { get; private set; }

    public Dentist(string name, Email email)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new BussinessRuleException("Dentist name cannot be empty.");
        }
        if (email is null)
        {
            throw new BussinessRuleException("Dentist email cannot be null.");
        }

        Name = name;
        Email = email;
        Id = Guid.CreateVersion7();
    }
}
