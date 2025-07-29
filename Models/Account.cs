using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

public class Account
{
  public Guid Id { get; set; }
  public required string AccountNumber { get; set; }
  public required AccountType AccountType { get; set; }
  public decimal Balance { get; set; }
  public bool IsActive { get; set; }
  public Guid CustomerId { get; set; }
  [ForeignKey("CustomerId")]
  public Customer Customer { get; set; }

  public DateTime DateCreated { get; set; }

}

public enum AccountType
{
  Savings,
  Current,
  FixedDeposit
}