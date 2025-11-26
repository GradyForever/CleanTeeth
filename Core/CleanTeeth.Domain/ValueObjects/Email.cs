using CleanTeeth.Domain.Exceptions;

namespace CleanTeeth.Domain.ValueObjects;

public record Email
{
    public string Value { get; }
    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new BusinessRuleException("Email is required.");
        }

        if (!value.Contains("@") || !value.Contains("."))
        {
            throw new BusinessRuleException("Email format is invalid.");
        }

        var parts = value.Split('@');
        if (parts.Length != 2)
        {
            throw new BusinessRuleException("Email format is invalid.");
        }

        var local = parts[0];
        var domain = parts[1];

        if (string.IsNullOrWhiteSpace(local))
        {
            throw new BusinessRuleException("Email format is invalid.");
        }

        if (!domain.Contains("."))
        {
            throw new BusinessRuleException("Email format is invalid.");
        }

        var labels = domain.Split('.');
        if (labels.Length < 2 || labels.Any(string.IsNullOrWhiteSpace))
        {
            throw new BusinessRuleException("Email format is invalid.");
        }

        Value = value;
    }
}
