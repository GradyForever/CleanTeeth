using CleanTeeth.Domain.Exceptions;

namespace CleanTeeth.Domain.Entities;

/// <summary>
/// 牙科诊所实体
/// </summary>
public class DentalOffice
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = null!;

    public DentalOffice(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new BusinessRuleException($"The {nameof(name)} is required.");
        }

        Name = name;
        // 顺序生成
        Id = Guid.CreateVersion7();
    }
}
