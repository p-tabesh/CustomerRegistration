using CustomerRegistration.Core.Exception;
using CustomerRegistration.Core.ValueObject;

namespace CustomerRegistration.Core.Entity;

public class Customer
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public NationalCode NationalCode { get; private set; }
    public Email Email { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public DateTime RegisterDate { get; private set; }

    private Customer() { }

    public Customer(string name, string lastName, NationalCode nationalCode, PhoneNumber phoneNumber, Email email)
    {
        Name = string.IsNullOrEmpty(name) ? throw new CustomException("Invalid name") : name;
        LastName = string.IsNullOrEmpty(lastName) ? throw new CustomException("Invalid Lastname") : lastName;
        NationalCode = nationalCode;
        PhoneNumber = phoneNumber;
        Email = email;
        RegisterDate = DateTime.Now;
    }

    public void ChangePhoneNumber(PhoneNumber newPhoneNumber)
    {
        PhoneNumber = newPhoneNumber;
    }

    public void ChangeEmail(Email newEmail)
    {
        Email = newEmail;
    }
}


