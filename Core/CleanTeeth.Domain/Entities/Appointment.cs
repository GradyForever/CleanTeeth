using CleanTeeth.Domain.Enums;

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
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Patient? Patient { get; private set; }
    public Dentist? Dentist { get; private set; }
    public DentalOffice? DentalOffice { get; private set; }
}
