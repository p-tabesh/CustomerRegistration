namespace CustomerRegistration.Core.ValueObject;

public class PhoneNumber
{
    public string Value { get; private set; }

    private PhoneNumber(string value) { }

    public static PhoneNumber Create(string value)
    {
        var phoneNumber = new PhoneNumber(value);   
        return phoneNumber;
    }
}
