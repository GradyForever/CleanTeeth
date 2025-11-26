using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Domain.Tests.ValueObjects;

public class EmailTests
{
    [Theory]
    [InlineData("user@example.com")]
    [InlineData("first.last@domain.co.uk")]
    [InlineData("name+tag@sub.domain.com")]
    public void Ctor_ValidEmail_SetsValue(string input)
    {
        var email = new Email(input);

        Assert.Equal(input, email.Value);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Ctor_NullOrWhitespace_ThrowsBusinessRuleException(string? input)
    {
        var ex = Assert.Throws<BusinessRuleException>(() => new Email(input!));
        Assert.Contains("Email is required.", ex.Message);
    }

    [Theory]
    [InlineData("userexample.com")]      // 缺少 @
    [InlineData("user@domain")]          // 缺少 .
    [InlineData("userdomain.com")]       // 缺少 @
    [InlineData("@domain.com")]          // 缺少本地部分
    [InlineData("user@.com")]            // 域名不含标识
    public void Ctor_InvalidFormat_ThrowsBusinessRuleException(string input)
    {
        var ex = Assert.Throws<BusinessRuleException>(() => new Email(input));
        Assert.Contains("Email format is invalid.", ex.Message);
    }
}