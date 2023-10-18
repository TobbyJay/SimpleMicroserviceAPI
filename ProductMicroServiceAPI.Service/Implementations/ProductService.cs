using ProductMicroserviceAPI.Model;
using ProductMicroServiceAPI.Service.Dtos;
using ProductMicroServiceAPI.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroServiceAPI.Servics.Implementations
{
	public class ProductService : IProductService
	{
		public ApiResponseDTO<List<Product>> GetProducts()
		{
		    var products = new List<Product>
			{
				new Product { ProductId = 1, Name = "Product 1", Price = 10.0m },
				new Product { ProductId = 2, Name = "Product 2", Price = 15.0m },
			};

			if (products.Count > 0)
			{
				return new ApiResponseDTO<List<Product>> { Success = true, Message = "Products retrieved Successfully", Data = products };
			}
			return new ApiResponseDTO<List<Product>> { Success = false, Message = "No Products found", Data = products };
		}
	}
}
