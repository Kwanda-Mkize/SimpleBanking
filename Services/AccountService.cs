public class AccountService
{
  private readonly IAccountRepository AccountRepository;

  public AccountService(IAccountRepository accountRepository)
  {
    AccountRepository = accountRepository;
  }

  public async Task<Account> AddAccountAsync(AccountDto accountDto)
  {
    var mapData = AccountMappper.MapToDomain(accountDto);
    return await AccountRepository.AddAccount(mapData);
  }
}