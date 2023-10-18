using ProductMicroserviceAPI.Model;
using System.Text;
using System.Text.Json;

namespace ProductMicroserviceAPI.Services
{
	public class ProductService : IProductService
	{
		private readonly ILogger<ProductService> _logger;
		public ProductService(HttpClient client, ILogger<ProductService> logger)
		{
			_logger = logger;
		}
		public List<Product> GetProducts()
		{
			var products = new List<Product>
			{
				new Product { ProductId = 1, Name = "Product 1", Price = 10.0m },
				new Product { ProductId = 2, Name = "Product 2", Price = 15.0m },
			};

			return products ?? new List<Product>();

		}

		public async Task<Orders> PlaceOrder(int productId, int quantity)
		{
			var order = new Orders{ ProductId = productId, Quantity = quantity };

			try
			{
				using (var _client = new HttpClient()) 
				{
					var payload = JsonSerializer.Serialize(order);
					var content = new StringContent(payload, Encoding.UTF8, "application/json");

					var response = await _client.PostAsync("https://localhost:7215/api/Orders/createOrder", content);

					if (response.IsSuccessStatusCode)
					{
						var result = await response.Content.ReadAsStringAsync();

						var data = JsonSerializer.Deserialize<Orders>(result);

						return data;
					}
				}				
			}
			catch (Exception ex)
			{
				_logger.LogInformation($"An Error Occured: {ex}");
			}

			return null;
		}
	}
}
