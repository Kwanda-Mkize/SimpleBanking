using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Connections;
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
    public async Task<IActionResult> AddAccount([FromBody] AddAccountDto accountDto)
    {
      var results = await _accountService.PerformActivity<AddAccountDto, AddAccountDto>(accountDto);
      return Ok(results);
    }
  }
}
