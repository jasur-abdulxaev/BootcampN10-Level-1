using Microsoft.AspNetCore.Mvc;
using N53_HT1.Interfaces;
using N53_HT1.Models;

namespace N53_HT1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var result = _userService.Get(user => true);
        return result.Any() ? Ok(result) : BadRequest();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create(User user)
    {
        var result = await _userService.CreateAsync(user);
        return Ok(result);
    }
}
