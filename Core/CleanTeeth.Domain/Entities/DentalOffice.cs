namespace CleanTeeth.Domain.Entities;

/// <summary>
/// 牙科诊所实体
/// </summary>
public class DentalOffice
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = null!;
}
