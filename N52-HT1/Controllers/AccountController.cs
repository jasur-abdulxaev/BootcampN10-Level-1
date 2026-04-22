using Microsoft.AspNetCore.Mvc;
using N52_HT1.Models;
using N52_HT1.Services.Interfaces;

namespace N52_HT1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] User user)
    {
        var result = _accountService.Register(user);

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var result = _accountService.GetById(id);

        if (!result.IsSuccess)
            return NotFound(result);

        return Ok(result);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _accountService.GetAll();
        return Ok(result);
    }

    [HttpPut]
    public IActionResult Update([FromBody] User user)
    {
        var result = _accountService.UpdateUser(user);

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var result = _accountService.DeleteUser(id);

        if (!result.IsSuccess)
            return NotFound(result);

        return Ok(result);
    }
}
