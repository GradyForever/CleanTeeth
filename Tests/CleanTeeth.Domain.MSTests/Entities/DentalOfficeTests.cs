using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Exceptions;

namespace CleanTeeth.Domain.MSTests.Entities;

[TestClass]
public class DentalOfficeTests
{
    [TestMethod]
    public void Constructor_ThrowsBusinessRuleException_WhenNameIsNullOrWhiteSpace()
    {
        Assert.Throws<BusinessRuleException>(() => new DentalOffice(null!));
        Assert.Throws<BusinessRuleException>(() => new DentalOffice(string.Empty));
        Assert.Throws<BusinessRuleException>(() => new DentalOffice("   "));
    }

    [TestMethod]
    public void Constructor_NoException_WhenNameIsValid()
    {
        var dentalOffice = new DentalOffice("Happy Smiles Dental");
        Assert.IsNotNull(dentalOffice);
        Assert.AreEqual("Happy Smiles Dental", dentalOffice.Name);
    }
}
