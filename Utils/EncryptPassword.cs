using System.Security.Cryptography;
using System.Text;

public class EncryptPassword
{
  public static string HashPassword(string Password)
  {
    string hashedPassword;
    var salt = Password.Reverse();
    var password = Password;
    var SaltedHash = password + salt;

    using (SHA256 sha = SHA256.Create())
    {
      byte[] hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(SaltedHash));
      string hash = BitConverter.ToString(hashBytes).Replace("-", "");
      hashedPassword = hash;
    }
    return hashedPassword;
  }
}