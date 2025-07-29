using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace SimpleBanking.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CustomerController : ControllerBase
  {
    private readonly IDempotency _store;

    public CustomerService _customerService { get; }
    public CustomerController(CustomerService customerService, IDempotency Store)
    {
      _customerService = customerService;
      _store = Store;
    }


    [HttpPost]
    public async Task<IActionResult> AddCustomer([FromBody] CustomerDto customerDto)
    {
      var idempotencyKey = Request.Headers["Idempotency-Key"].FirstOrDefault();

      if (string.IsNullOrEmpty(idempotencyKey))
        return BadRequest("Missing Idempotency-Key");

      if (_store.TryGetResponse(idempotencyKey, out var cachedResponse))
        return Ok(cachedResponse);

      var results = await _customerService.PerformActivity<CustomerDto, Customer>(customerDto);
      _store.SaveResponse(idempotencyKey, results);
      return Ok(results);
    }
  }
}