
public class AccountRepository : IAccountRepository
{
  private readonly DBcontext _dbcontext;
  public AccountRepository(DBcontext dbcontext)
  {
    _dbcontext = dbcontext;

  }
  public async Task<Account> AddAccount(Account account)
  {
    await _dbcontext.Accounts.AddAsync(account);
    return account;
    // throw new InvalidOperationException("Exception at repository level");
    // await _dbcontext.SaveChangesAsync();
  }


}