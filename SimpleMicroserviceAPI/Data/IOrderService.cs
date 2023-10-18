using SimpleMicroserviceAPI.Models;

namespace SimpleMicroserviceAPI.Data
{
	public interface IOrderService
	{
		public Orders CreateOrder(Orders order);
		public Orders GetOrder(int orderId);
	}
}
