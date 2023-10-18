using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductMicroserviceAPI.Controllers;
using ProductMicroserviceAPI.Model;
using ProductMicroServiceAPI.Service.Interfaces;

namespace ProductMicroserviceAPI.Tests
{
	public class UnitTest1
	{
		[Theory]
		[InlineData(5, 1)] // Test Case 1: Valid input
		[InlineData(0, 1)] // Test Case 2: Invalid quantity
		[InlineData(3, 0)] // Test Case 3: Invalid product ID
		public void PlaceOrder_ReturnsCorrectResult(int quantity, int productId)
		{
			// Arrange
			var productServiceMock = new Mock<ProductMicroserviceAPI.Services.IProductService>();
			var expectedProducts = new Orders();

			if (quantity > 0 && productId > 0)
			{
				// If the input is valid, set up the expected result
				expectedProducts = new Orders
				{
					 Quantity = quantity,
					 ProductId = productId
				};
			}

			productServiceMock.Setup(service => service.PlaceOrder(productId, quantity)).ReturnsAsync(expectedProducts);

			var controller = new ProductsController(productServiceMock.Object);

			// Act
			var result = controller.PlaceOrder(quantity, productId);

			// Assert
			if (quantity > 0 && productId > 0)
			{
				// If the input is valid, expect an OK response with the expected products
				var okResult = Assert.IsType<OkObjectResult>(result);
				var returnedProducts = okResult.Value as List<Product>;
				Assert.NotNull(returnedProducts);

			}
			else
			{
				// If the input is invalid, expect a BadRequest or InternalServerError response
				Assert.True(result is BadRequestResult || result is ObjectResult);
			}
		}
	}
}