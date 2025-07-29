public class CustomerService : TransactionAdaptor
{
  public ICustomerRepository CustomerRepository { get; }
  public CustomerService(ICustomerRepository customerRepository, DBcontext dBcontext) : base(dBcontext)
  {
    CustomerRepository = customerRepository;
  }



  public override async Task<TRes> ExecuteTask<TDto, TRes>(TDto Dto)
  {
    if (Dto is not CustomerDto customerDto)
      throw new ArgumentException("Invalid DTO type for adding account");


    var mappedData = CustomerMapper.MaptoDomain(customerDto);
    return (TRes)(Object)await CustomerRepository.Add(mappedData);
  }
}