using Microsoft.EntityFrameworkCore;

public class AccountService : TransactionAdaptor
{
  private readonly IAccountRepository AccountRepository;

  public AccountService(DBcontext dbContext, IAccountRepository accountRepository) : base(dbContext)
  {
    AccountRepository = accountRepository;
  }

  public override async Task<TRes> ExecuteTask<TDto, TRes>(TDto dto)
  {
    if (dto is not AddAccountDto accountDto)
      throw new ArgumentException("Invalid DTO type for Adding account");

    var mappedData = AccountMappper.MapToDomain(accountDto);
    return (TRes)(Object)await AccountRepository.AddAccount(mappedData);
  }
}