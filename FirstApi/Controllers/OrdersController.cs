using FirstApi.Models;
using FirstApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    // GET api/orders
    [HttpGet]
    public IActionResult GetAll()
        => Ok(_orderService.GetAll());

    // GET api/orders/{id}
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var order = _orderService.GetById(id);
        if (order is null) return NotFound($"Order {id} topilmadi.");
        return Ok(order);
    }

    // POST api/orders
    [HttpPost]
    public IActionResult Create([FromBody] Order order)
    {
        var created = _orderService.Create(order);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT api/orders
    [HttpPut]
    public IActionResult Update([FromBody] Order order)
    {
        var updated = _orderService.Update(order);
        if (updated is null) return NotFound($"Order {order.Id} topilmadi.");
        return Ok(updated);
    }
}