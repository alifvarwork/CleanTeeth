
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Test.Domain.ValueObjects;

[TestClass]
public class EmailTest
{
    [TestMethod]
    public void Email_ShouldThrowException_WhenEmailIsEmpty()
    {
        // Arrange
        string emptyEmail = "";
        // Act & Assert
        var exception = Assert.Throws<BussinessRuleException>(() => new Email(emptyEmail));
        Assert.AreEqual("Patient email cannot be empty.", exception.Message);
    }

    [TestMethod]
    public void Email_ShouldThrowException_WhenEmailIsInvalid()
    {
        // Arrange
        string invalidEmail = "invalidemail.com";
        // Act & Assert
        var exception = Assert.Throws<BussinessRuleException>(() => new Email(invalidEmail));
        Assert.AreEqual("Patient email must be a valid email address.", exception.Message);
    }
    
    [TestMethod]
    public void Email_ShouldCreateInstance_WhenEmailIsValid()
    {
        // Arrange
        string validEmail = "test@example.com";
        // Act
        var email = new Email(validEmail);
        // Assert
        Assert.AreEqual(validEmail, email.Value);
    }
}
