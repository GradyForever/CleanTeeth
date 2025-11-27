using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Domain.MSTests.Entities;

[TestClass]
public class PatientTests
{
    [TestMethod]
    public void Constructor_ThrowsBusinessRuleException_WhenNameIsNullOrWhiteSpace()
    {
        var validEmail = new Email("john@clinic.com");
        Assert.Throws<BusinessRuleException>(() => new Patient(null!, validEmail));
        Assert.Throws<BusinessRuleException>(() => new Patient(string.Empty, validEmail));
        Assert.Throws<BusinessRuleException>(() => new Patient("   ", validEmail));
    }

    [TestMethod]
    public void Constructor_ThrowsBusinessRuleException_WhenEmailIsNull()
    {
        Assert.Throws<BusinessRuleException>(() => new Patient("John Doe", null!));
    }

    [TestMethod]
    public void Constructor_NoException_WhenNameAndEmailAreValid()
    {
        var email = new Email("john@clinic.com");
        var patient = new Patient("John Doe", email);
        Assert.IsNotNull(patient);
        Assert.AreEqual("John Doe", patient.Name);
        Assert.AreEqual(email, patient.Email);
        Assert.IsTrue(patient.Id != Guid.Empty);
    }
}
