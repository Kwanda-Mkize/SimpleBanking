public interface ICustomerRepository
{
  public Task<Customer> Add(Customer customer);
}