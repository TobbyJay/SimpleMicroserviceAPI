using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleMicroserviceAPI.Data;
using SimpleMicroserviceAPI.Models;
using System.Net;

namespace SimpleMicroserviceAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderService _orderService;
		public OrdersController(IOrderService orderService)
		{
			_orderService = orderService;
		}
		[HttpGet("getOrder")]
	    [ProducesResponseType(typeof(Orders), (int)HttpStatusCode.OK)]
	    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
	    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
		public IActionResult GetOrder([FromQuery] int orderId)
		{
			var products = _orderService.GetOrder(orderId);
			return Ok(products);
		}

		[HttpPost("createOrder")]
		public IActionResult CreateOrder([FromBody] Orders order)
		{
			var create = _orderService.CreateOrder(order);
			return Ok(create);
		}

	}
}
