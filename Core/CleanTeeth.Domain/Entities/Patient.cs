namespace CleanTeeth.Domain.Entities;

/// <summary>
/// 患者实体
/// </summary>
public class Patient
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = null!;

    public string Email { get; private set; } = null!;
}
