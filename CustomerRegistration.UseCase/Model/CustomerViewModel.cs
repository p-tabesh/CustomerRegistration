namespace CustomerRegistration.UseCase.Model;

public record CustomerViewModel(int Id, string FullName, string NationalCode, string PhoneNumber, string Email)
{
    public static CustomerViewModel Parse(Core.Entity.Customer customer)
    {
        return new CustomerViewModel(customer.Id,
                                     string.Concat(customer.Name, customer.LastName),
                                     customer.NationalCode.ToString(),
                                     customer.PhoneNumber.ToString(),
                                     customer.Email.ToString());
    }

    public static IEnumerable<CustomerViewModel> Parse(IEnumerable<Core.Entity.Customer> customers)
    {
        var models = new List<CustomerViewModel>();

        foreach (var customer in customers)
            models.Add(Parse(customer));

        return models;
    }

    public override string ToString()
    {
        return $"CustomerId: {Id}, Customer Title: {FullName}, NationalCode: {NationalCode}, PhoneNumber: {PhoneNumber}, Email: {Email}";
    }
};
