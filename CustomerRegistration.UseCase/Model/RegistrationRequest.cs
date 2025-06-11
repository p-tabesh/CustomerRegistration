namespace CustomerRegistration.UseCase.Model;

public record RegistrationRequest(string Name, string LastName,string NationalCode, string PhoneNumber, string Email);

