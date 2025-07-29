using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.OpenApi.Any;

public abstract class TransactionAdaptor
{

  protected readonly DBcontext _dBcontext;
  private IDbContextTransaction _transaction;

  public TransactionAdaptor(DBcontext dBcontext)
  {
    _dBcontext = dBcontext;
  }

  public abstract Task<TRes> ExecuteTask<TDto, TRes>(TDto Dto);

  public async Task<TRes> PerformActivity<TDto, TRes>(TDto Dto)
  {
    try
    {
      await BeginTransaction();
      var result = await ExecuteTask<TDto, TRes>(Dto);
      await CommitTransaction();
      return result;
    }
    catch (Exception ex)
    {
      await RollbackTransaction();
      Console.WriteLine(ex.Message);
      return default(TRes);
    }
  }

  public async Task BeginTransaction()
  {
    _transaction = await _dBcontext.Database.BeginTransactionAsync();
    Console.WriteLine("======================Transaction Started======================");
  }
  public async Task CommitTransaction()
  {
    await _dBcontext.SaveChangesAsync();
    await _transaction.CommitAsync();

    Console.WriteLine("======================Transaction Commited======================");
  }
  public async Task RollbackTransaction()
  {
    await _transaction.RollbackAsync();
    Console.WriteLine("======================Transaction Rolled back======================");
  }
}