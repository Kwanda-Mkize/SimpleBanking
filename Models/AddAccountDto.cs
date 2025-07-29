public class AddAccountDto
{
  public required AccountType AccountType { get; set; }
  public Guid CustomerId { get; set; }
  public decimal Balance { get; set; }
  public bool IsActive { get; set; } = true;
}