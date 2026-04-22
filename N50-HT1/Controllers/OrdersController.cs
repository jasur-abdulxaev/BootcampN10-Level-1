using Microsoft.AspNetCore.Mvc;
using N50_HT1.Services.Interfaces;

namespace N50_HT1.Controllers;


[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IUserOrderService _userOrderService;

    public OrdersController(IUserOrderService userOrderService)
    {
        _userOrderService = userOrderService;
    }

    // Get Api/orders/by-user/1
    [HttpGet("by-user/{userId:int}")]
    public IActionResult GetOrdersByuser([FromRoute] int userId)
    {
        var result = _userOrderService.GetUserOrdersByUserId(userId);

        if (result is null)
            return NotFound(new { message = $"UserId={userId} topilmadi." });

        return Ok(result);
    }
}
