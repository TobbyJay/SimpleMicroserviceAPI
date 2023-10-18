using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ProductMicroserviceAPI.Services;
using System.Text;

namespace ProductMicroserviceAPI.Extensions
{
	public static class ServiceExtensions
	{
		public static void RegisterProductServices(this IServiceCollection services)
		{
			services.AddScoped<IProductService, ProductService>();
		}
		
		public static void RegisterJWTAuth(this IServiceCollection services)
		{
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				   .AddJwtBearer(options =>
				   {
					   options.TokenValidationParameters = new TokenValidationParameters
					   {
						   ValidateIssuer = false,
						   ValidateAudience = false,
						   ValidateLifetime = true,
						   ValidateIssuerSigningKey = true,
						   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKey")) // Replace with your secret key
					   };
				   });
		}

		public static void ConfigureUrls(this IServiceCollection services)
		{
			var baseAddress = new Dictionary<string, string>()
			{
				{ "OrdersBaseUrl", "http://www.mocky.io/v2/" },
			};

			services.AddCustomHttpClients(baseAddress);
		}
		public static IServiceCollection AddCustomHttpClients(this IServiceCollection services, Dictionary<string, string> baseAddresses)
		{
			foreach (var (clientName, baseAddress) in baseAddresses)
			{
				services.AddHttpClient(clientName, client =>
				{
					client.BaseAddress = new Uri(baseAddress);
				});
			}

			return services;
		}
	}
}
