using CustomerRegistration.Core.Exception;

namespace CustomerRegistration.Core.ValueObject;

public class NationalCode : BaseValueObject
{
    private NationalCode()
    {
        
    }
    private NationalCode(string value)
    {
        Validate(value);
        Value = value;
    }
    public static NationalCode Create(string value)
    {
        var nationalCode = new NationalCode(value);
        return nationalCode;
    }

    private void Validate(string value)
    {
        if (string.IsNullOrEmpty(value) || value.Length != 10)
            throw new ArgumentException("Invalid NationalCode");
    }
}
