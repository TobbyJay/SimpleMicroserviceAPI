using ProductMicroserviceAPI.Model;
using ProductMicroServiceAPI.Service.Dtos;

namespace ProductMicroServiceAPI.Service.Interfaces
{
	public interface IProductService
	{
		ApiResponseDTO<List<Product>> GetProducts();
	}
}
