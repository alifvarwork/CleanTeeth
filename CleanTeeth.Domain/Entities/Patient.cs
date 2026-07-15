using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Domain.Entities;

public class Patient
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public Email Email { get; private set; }

    public Patient(string name, Email email)
    {
        if(string.IsNullOrWhiteSpace(name))
        {
            throw new BussinessRuleException("Patient name cannot be empty.");
        }

        if(email is null)
        {
            throw new BussinessRuleException("Patient email cannot be null.");
        }

        Name = name;
        Email = email;
        Id = Guid.CreateVersion7();
    }
}
