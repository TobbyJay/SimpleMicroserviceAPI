using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroserviceAPI.Model;
using ProductMicroserviceAPI.Services;
using System.Net;

namespace ProductMicroserviceAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
        private readonly IProductService _productService;
		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet("getProducts")]
		[ProducesResponseType(typeof(List<Product>), (int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
		public IActionResult GetProducts()
		{
			var products = _productService.GetProducts();
			return Ok(products);
		}

		[HttpGet("placeOrder")]
		[ProducesResponseType(typeof(List<Product>), (int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
		public IActionResult PlaceOrder([FromQuery] int quantity, int productId)
		{
			var products = _productService.PlaceOrder(productId,quantity);
			return Ok(products);
		}
			
	}
}
