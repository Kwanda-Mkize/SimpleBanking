using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace SimpleBanking.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AccountController : ControllerBase
  {
    private readonly AccountService _accountService;
    public AccountController(AccountService accountService)
    {
      _accountService = accountService;
    }

    [HttpPost]
    public async Task<IActionResult> AddAccount([FromBody] AccountDto accountDto)
    {
      var account = await _accountService.AddAccountAsync(accountDto);
      return Ok(account);
    }
  }
}