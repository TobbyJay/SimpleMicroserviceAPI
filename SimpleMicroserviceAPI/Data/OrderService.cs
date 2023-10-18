using SimpleMicroserviceAPI.Models;

namespace SimpleMicroserviceAPI.Data
{
	public class OrderService : IOrderService
	{
		private List<Orders> ordersList = new List<Orders>();
		private int nextOrderId = 1;
		public Orders CreateOrder(Orders order)
		{

			order.OrderId = nextOrderId++;
			ordersList.Add(order);

			return order;
		}

		public Orders GetOrder(int orderId)
		{
			var order = ordersList.Where(o=> o.OrderId == orderId).FirstOrDefault();

			return order ?? null;
		}
	}
}
