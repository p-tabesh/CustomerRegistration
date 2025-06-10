namespace CustomerRegistration.Core.ValueObject;

public class Email : BaseValueObject
{
    private Email(string value)
    {
        Validate(value);
        Value = value;
    }

    public override BaseValueObject Create(string value)
    {
        Email email = new(value);
        return email;
    }

    public override void Validate(string value)
    {
        throw new NotImplementedException();
    }
}
