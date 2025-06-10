namespace CustomerRegistration.Core.ValueObject;

public class NationalCode : BaseValueObject
{
    private NationalCode(string value)
    {
        Validate(value);
        Value = value;
    }
    public override BaseValueObject Create(string value)
    {
        throw new NotImplementedException();
    }

    public override void Validate(string value)
    {
        throw new NotImplementedException();
    }
}
