using ProductMicroserviceAPI.Model;

namespace ProductMicroserviceAPI.Services
{
	public interface IProductService
	{
		 List<Product> GetProducts();
		 public Task<Orders> PlaceOrder(int productId, int quantity);
	}
}
