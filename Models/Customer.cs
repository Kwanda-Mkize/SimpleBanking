using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Customer
{
  [Key]
  public Guid Id { get; set; }
  public required string FirstName { get; set; }
  public required string LastName { get; set; }
  [StringLength(10)]
  [Phone]
  public required string PhoneNumber { get; set; }

  [StringLength(13)]
  public required string IdNumber { get; set; }

  [Compare("ConfirmPassword")]
  public required string Password { get; set; }

  [NotMapped]
  public required string ConfirmPassword { get; set; }

  public DateTime DateJoined { get; set; }

  public ICollection<Account> Accounts { get; set; } = new List<Account>();
}