public class AccountMappper
{
  public static Account MapToDomain(AccountDto accountDto)
  {
    var id = Guid.NewGuid();

    return new Account()
    {
      Id = id,
      FirstName = accountDto.FirstName,
      LastName = accountDto.LastName,
      Email = accountDto.Email,
      Password = accountDto.Password,
      Balance = accountDto.Balance,
    };
  }
}