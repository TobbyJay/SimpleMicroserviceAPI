using Microsoft.AspNetCore.Mvc;
using Moq;
using SimpleMicroserviceAPI.Controllers;
using SimpleMicroserviceAPI.Data;
using SimpleMicroserviceAPI.Models;
using Xunit;

namespace OrderMicroserviceAPI.Tests.Controller
{
	public class OrdersControllerTests
	{
		[Theory]
		[InlineData(1, 30)] // Test Case 1
		[InlineData(2, 25)] // Test Case 2
		public void CreateOrder_ReturnsOkResult_WhenOrderIsCreated(int productId, int quantity)
		{
			// Arrange
			var order = new Orders
			{
				 ProductId = productId, 
				 Quantity = quantity
			};
			
			var expectedresult = new Orders
			{
				 OrderId = 1,
				 ProductId = productId, 
				 Quantity = quantity
			};

			var orderServiceMock = new Mock<IOrderService>();
			orderServiceMock.Setup(service => service.CreateOrder(It.IsAny<Orders>())).Returns(expectedresult);

			var controller = new OrdersController(orderServiceMock.Object);

			// Act
			var result = controller.CreateOrder(order);

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);

			orderServiceMock.Verify(service => service.CreateOrder(order), Times.Once);
		}

	}
}
