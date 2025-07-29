
using Microsoft.EntityFrameworkCore;

public class CustomerRepository : ICustomerRepository
{

  private DBcontext _dbcontext;
  public CustomerRepository(DBcontext dBcontext)
  {
    _dbcontext = dBcontext;
  }


  public async Task<Customer> Add(Customer customer)
  {
    var existingCustomer = await _dbcontext.Customers.FirstOrDefaultAsync(c => c.IdNumber == customer.IdNumber);
    if (existingCustomer != null)
    {
      throw new InvalidOperationException("Customer already exists");
    }
    await _dbcontext.Customers.AddAsync(customer);
    return customer;
  }
}