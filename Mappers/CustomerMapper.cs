public class CustomerMapper
{
  public static Customer MaptoDomain(CustomerDto customerDto)
  {
    var id = Guid.NewGuid();
    string PasswordHash = EncryptPassword.HashPassword(customerDto.Password);
    return new Customer()
    {
      Id = id,
      FirstName = customerDto.FirstName,
      LastName = customerDto.LastName,
      PhoneNumber = customerDto.PhoneNumber,
      IdNumber = customerDto.IdNumber,
      ConfirmPassword = customerDto.ConfirmPassword,
      Password = PasswordHash,
      DateJoined = DateTime.Now
    };
  }
}