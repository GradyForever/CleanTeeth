using CleanTeeth.Domain.Exceptions;

namespace CleanTeeth.Domain.Entities;

/// <summary>
/// 牙医实体
/// </summary>
public class Dentist
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = null!;

    public string Email { get; private set; } = null!;

    public Dentist(string name, string email)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new BusinessRuleException($"The {nameof(name)} is required.");
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            throw new BusinessRuleException($"The {nameof(email)} is required.");
        }

        if (!email.Contains("@") || !email.Contains("."))
        {
            throw new BusinessRuleException($"The {nameof(email)} format is invalid.");
        }

        Name = name;
        Email = email;
        // 顺序生成
        Id = Guid.CreateVersion7();
    }
}
