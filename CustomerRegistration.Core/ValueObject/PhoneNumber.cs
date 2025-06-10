namespace CustomerRegistration.Core.ValueObject;

public class PhoneNumber
{
    public string Value { get; private set; }

    private PhoneNumber(string value)
    {
        Validate(value);
        Value = value;
    }

    public static PhoneNumber Create(string value)
    {
        var phoneNumber = new PhoneNumber(value);
        return phoneNumber;
    }

    private void Validate(string value)
    {
        if (string.IsNullOrEmpty(Value) || !value.StartsWith("09") || value.Length != 11)
            throw new ArgumentException("Invalid Phone Number");
    }
}
