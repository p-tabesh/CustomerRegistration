namespace CustomerRegistration.Core.ValueObject;

public class Email : BaseValueObject
{
    private Email(string value)
    {
        Validate(value);
        Value = value;
    }

    public static Email Create(string value)
    {
        Email email = new(value);
        return email;
    }

    private void Validate(string value)
    {
        throw new NotImplementedException();
    }
}
