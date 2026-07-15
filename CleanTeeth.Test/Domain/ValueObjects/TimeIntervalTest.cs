using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Test.Domain.ValueObjects;

[TestClass]
public class TimeIntervalTest
{
    [TestMethod]
    public void TimeInterval_ShouldThrowArgumentException_WhenStartIsAfterEnd()
    {
        // Arrange
        var start = new DateTime(2024, 1, 1, 10, 0, 0);
        var end = new DateTime(2024, 1, 1, 9, 0, 0);
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new TimeInterval(start, end));
    }

    [TestMethod]
    public void TimeInterval_ShouldCreateInstance_WhenStartIsBeforeEnd()
    {
        // Arrange
        var start = new DateTime(2024, 1, 1, 9, 0, 0);
        var end = new DateTime(2024, 1, 1, 10, 0, 0);
        // Act
        var timeInterval = new TimeInterval(start, end);
        // Assert
        Assert.AreEqual(start, timeInterval.Start);
        Assert.AreEqual(end, timeInterval.End);
    }
}
