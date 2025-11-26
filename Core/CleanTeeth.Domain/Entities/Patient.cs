using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Domain.Entities;

/// <summary>
/// 患者实体
/// </summary>
public class Patient
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = null!;

    public Email Email { get; private set; } = null!;

    public Patient(string name, Email email)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new BusinessRuleException($"The {nameof(name)} is required.");
        }
        
        if (email is null)
        {
            throw new BusinessRuleException($"The {nameof(email)} is required.");
        }

        Name = name;
        Email = email;
        // 顺序生成
        Id = Guid.CreateVersion7();
    }
}
