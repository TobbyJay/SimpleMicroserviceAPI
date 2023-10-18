using ProductMicroserviceAPI.Model;
using ProductMicroServiceAPI.Services.Dtos;

namespace ProductMicroServiceAPI.Services.Interfaces
{
	public interface IProductService
	{
		ApiResponseDTO<List<Product>> GetProducts();
	}
}
