using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Enums;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Domain.MSTests.Entities;

[TestClass]
public class AppointmentTests
{
    private readonly Guid _patientId = Guid.NewGuid();
    private readonly Guid _dentistId = Guid.NewGuid();
    private readonly Guid _dentalOfficeId = Guid.NewGuid();
    private static TimeInterval FutureInterval => new(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));
    private static TimeInterval PastInterval => new(DateTime.Now.AddHours(-2), DateTime.Now.AddHours(-1));

    [TestMethod]
    public void Constructor_WithValidData_SetsProperties()
    {
        var interval = FutureInterval;
        var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, interval);
        Assert.AreEqual(_patientId, appointment.PatientId);
        Assert.AreEqual(_dentistId, appointment.DentistId);
        Assert.AreEqual(_dentalOfficeId, appointment.DentalOfficeId);
        Assert.AreEqual(interval, appointment.TimeInterval);
        Assert.AreEqual(AppiontmentStatus.Scheduled, appointment.Status);
        Assert.AreNotEqual(Guid.Empty, appointment.Id);
        Assert.IsNull(appointment.Patient);
        Assert.IsNull(appointment.Dentist);
        Assert.IsNull(appointment.DentalOffice);
    }

    [TestMethod]
    public void Constructor_ThrowsBusinessRuleException_WhenStartTimeInPast()
    {
        Assert.Throws<BusinessRuleException>(() => new Appointment(_patientId, _dentistId, _dentalOfficeId, PastInterval));
    }

    [TestMethod]
    public void Cancel_Succeeds_WhenStatusScheduled()
    {
        var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, FutureInterval);
        appointment.Cancel();
        Assert.AreEqual(AppiontmentStatus.Canceled, appointment.Status);
    }

    [TestMethod]
    public void Cancel_ThrowsBusinessRuleException_WhenStatusNotScheduled()
    {
        var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, FutureInterval);
        appointment.Complete();
        Assert.Throws<BusinessRuleException>(() => appointment.Cancel());
        Assert.AreEqual(AppiontmentStatus.Completed, appointment.Status);
    }

    [TestMethod]
    public void Cancel_ThrowsBusinessRuleException_WhenAlreadyCanceled()
    {
        var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, FutureInterval);
        appointment.Cancel();
        Assert.Throws<BusinessRuleException>(() => appointment.Cancel());
        Assert.AreEqual(AppiontmentStatus.Canceled, appointment.Status);
    }

    [TestMethod]
    public void Complete_Succeeds_WhenStatusScheduled()
    {
        var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, FutureInterval);
        appointment.Complete();
        Assert.AreEqual(AppiontmentStatus.Completed, appointment.Status);
    }

    [TestMethod]
    public void Complete_ThrowsBusinessRuleException_WhenStatusNotScheduled()
    {
        var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, FutureInterval);
        appointment.Cancel();
        Assert.Throws<BusinessRuleException>(() => appointment.Complete());
        Assert.AreEqual(AppiontmentStatus.Canceled, appointment.Status);
    }

    [TestMethod]
    public void Sequence_CompleteThenCancel_ThrowsAndStatusRemainsCompleted()
    {
        var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, FutureInterval);
        appointment.Complete();
        Assert.Throws<BusinessRuleException>(() => appointment.Cancel());
        Assert.AreEqual(AppiontmentStatus.Completed, appointment.Status);
    }
}
