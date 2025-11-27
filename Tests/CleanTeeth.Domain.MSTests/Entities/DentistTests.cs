using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Domain.MSTests.Entities;

[TestClass]
public class DentistTests
{
    [TestMethod]
    public void Constructor_ThrowsBusinessRuleException_WhenNameIsNullOrWhiteSpace()
    {
        var validEmail = new Email("john@clinic.com");
        Assert.Throws<BusinessRuleException>(() => new Dentist(null!, validEmail));
        Assert.Throws<BusinessRuleException>(() => new Dentist(string.Empty, validEmail));
        Assert.Throws<BusinessRuleException>(() => new Dentist("   ", validEmail));
    }

    [TestMethod]
    public void Constructor_ThrowsBusinessRuleException_WhenEmailIsNull()
    {
        Assert.Throws<BusinessRuleException>(() => new Dentist("Dr. John Doe", null!));
    }

    [TestMethod]
    public void Constructor_NoException_WhenNameAndEmailAreValid()
    {
        var email = new Email("dr.john@clinic.com");
        var dentist = new Dentist("Dr. John Doe", email);
        Assert.IsNotNull(dentist);
        Assert.AreEqual("Dr. John Doe", dentist.Name);
        Assert.AreEqual(email, dentist.Email);
        Assert.IsTrue(dentist.Id != Guid.Empty);
    }
}
