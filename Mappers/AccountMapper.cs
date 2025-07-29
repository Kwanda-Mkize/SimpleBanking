using System.Security.Cryptography;
using System.Text;

public class AccountMappper
{
  public static Account MapToDomain(AddAccountDto accountDto)
  {
    var id = Guid.NewGuid();

    Random random = new Random();
    string accNumber = string.Join("", Enumerable.Range(0, 10).Select(_ => random.Next(0, 10)));
    // throw new InvalidOperationException("Exception at Mapper level");

    return new Account()
    {

      Id = id,
      AccountNumber = accNumber,
      AccountType = accountDto.AccountType,
      Balance = 0,
      IsActive = accountDto.IsActive,
      CustomerId = accountDto.CustomerId,
      DateCreated = DateTime.Now

    };
  }
}
