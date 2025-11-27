using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Domain.MSTests.ValueObjects;

[TestClass]
public class EmailTests
{
    [TestMethod]
    public void Constructor_ThrowsBusinessRuleException_WhenEmailIsNull()
    {
        Assert.Throws<BusinessRuleException>(() => new Email(null!));
    }

    [TestMethod]
    public void Constructor_ThrowsBusinessRuleException_WhenEmailIsInvalid()
    {
        Assert.Throws<BusinessRuleException>(() => new Email("grady.com"));
    }

    [TestMethod]
    public void Constructor_NoException_WhenEmailIsValid()
    {
        var email = new Email("grady@123.com");
        Assert.IsNotNull(email);
        Assert.AreEqual("grady@123.com", email.Value);
    }
}
