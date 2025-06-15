using System.Text.RegularExpressions;

namespace CustomerRegistration.Core.ValueObject;

public class Email : BaseValueObject
{
    private Email()
    {
        
    }
    private Email(string value)
    {
        Validate(value);
        Value = value;
    }

    public static Email Create(string value)
    {
        var email = new Email(value);
        return email;
    }

    private void Validate(string value)
    {
        if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new ArgumentException("Invalid email");
    }
}
