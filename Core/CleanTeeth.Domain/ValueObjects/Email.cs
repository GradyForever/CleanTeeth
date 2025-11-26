namespace CleanTeeth.Domain.ValueObjects;

public record Email
{
    public string Value { get; }
    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Email is required.", nameof(value));
        }
        if (!value.Contains("@") || !value.Contains("."))
        {
            throw new ArgumentException("Email format is invalid.", nameof(value));
        }

        Value = value;
    }
}
