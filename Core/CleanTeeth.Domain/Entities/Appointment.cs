using CleanTeeth.Domain.Enums;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Domain.Entities;

/// <summary>
/// 预约实体
/// </summary>
public class Appointment
{
    public Guid Id { get; private set; }
    public Guid PatientId { get; private set; }
    public Guid DentistId { get; private set; }
    public Guid DentalOfficeId { get; private set; }
    public AppiontmentStatus Status { get; private set; }
    public TimeInterval TimeInterval { get; private set; }
    public Patient? Patient { get; private set; }
    public Dentist? Dentist { get; private set; }
    public DentalOffice? DentalOffice { get; private set; }

    public Appointment(Guid patientId, Guid dentistId, Guid dentalOfficeId, TimeInterval timeInterval)
    {
        if (timeInterval.Start < DateTime.Now)
        {
            throw new ArgumentException("The start time can not be in the past.");
        }

        PatientId = patientId;
        DentistId = dentistId;
        DentalOfficeId = dentalOfficeId;
        TimeInterval = timeInterval;
        Status = AppiontmentStatus.Scheduled;
        // 顺序生成
        Id = Guid.CreateVersion7();
    }

    public void Cancel()
    {
        if (Status == AppiontmentStatus.Scheduled)
        {
            throw new InvalidOperationException("Only scheduled appointments can be canceled.");
        }

        Status = AppiontmentStatus.Canceled;
    }

    public void Complete()
    {
        if (Status != AppiontmentStatus.Scheduled)
        {
            throw new InvalidOperationException("Only scheduled appointments can be completed.");
        }

        Status = AppiontmentStatus.Completed;
    }
}
