using FirstApi.Models;
using FirstApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IUserOrdersService _userOrdersService;

    public UsersController(
        IUserService userService,
        IUserOrdersService userOrdersService)
    {
        _userService = userService;
        _userOrdersService = userOrdersService;
    }

    // GET api/ users
    [HttpGet]
    public IActionResult GetAll()
        => Ok(_userService.GetAll());


    // GET api/users/{id}
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var user = _userService.GetById(id);
        if (user is null) return NotFound($"User {id} topilmadi.");
        return Ok(user);
    }

    // POST api/ users
    [HttpPost]
    public IActionResult Create([FromBody] User user)
    {
        var created = _userService.Create(user);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT api/ users
    [HttpPut]
    public IActionResult Update([FromBody] User user)
    {
        var updated = _userService.Update(user);
        if (updated is null) return NotFound($"User {user.Id} topilmadi.");
        return Ok(updated);
    }

    // GET api/ users/{id}/orders
    [HttpGet("{id:guid}/orders")]
    public IActionResult GetUserOrders(Guid id)
    {
        var user = _userService.GetById(id);
        if (user is null) return NotFound($"User {id} topilmadi.");

        var orders = _userOrdersService.GetOrdersByUserId(id);
        return Ok(orders);
    }
}
