using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using N50_HT1.Services.Interfaces;

namespace N50_HT1.Controllers;


[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    // GET api/users
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_userService.GetAll());
    }

    // GET api/users/1
    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var user = _userService.GetById(id);
        return user is null ? NotFound() : Ok(user);
    }
}
