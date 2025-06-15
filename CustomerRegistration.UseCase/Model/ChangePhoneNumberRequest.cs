namespace CustomerRegistration.UseCase.Model;

public record ChangePhoneNumberRequest(string NationalCode, string newPhoneNumber);