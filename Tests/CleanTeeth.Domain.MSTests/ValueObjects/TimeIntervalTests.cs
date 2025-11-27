using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Domain.MSTests.ValueObjects;

[TestClass]
public class TimeIntervalTests
{
    [TestMethod]
    public void Constructor_ThrowsBusinessRuleException_WhenEndTimeIsLessThanStartTime()
    {
        Assert.Throws<BusinessRuleException>(() => new TimeInterval(DateTime.Now, DateTime.Now.AddDays(-1)));
    }

    [TestMethod]
    public void Constructor_NoException_WhenEndTimeIsGreaterThanStartTime()
    {
        var startTime = DateTime.Now;
        var endTime = DateTime.Now.AddDays(1);
        var timeInterval = new TimeInterval(startTime, endTime);
        Assert.IsNotNull(timeInterval);
        Assert.AreEqual(startTime, timeInterval.Start);
        Assert.AreEqual(endTime, timeInterval.End);
    }
}
