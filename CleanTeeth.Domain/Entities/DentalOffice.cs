using CleanTeeth.Domain.Exceptions;

namespace CleanTeeth.Domain.Entities;

public class DentalOffice
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    public DentalOffice(string name)
    {
        if(string.IsNullOrWhiteSpace(name))
        {
            throw new BussinessRuleException("Dental office name cannot be empty.");
        }

        Name = name;
        Id = Guid.CreateVersion7();
    }
}
