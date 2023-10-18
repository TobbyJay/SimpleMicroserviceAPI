using Microsoft.Extensions.DependencyInjection;
using ProductMicroServiceAPI.Services.Implementations;
using ProductMicroServiceAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroServiceAPI.Services.Extensions
{
	public static class ServiceExtensions
	{
		public static void RegisterProductServices(this IServiceCollection service)
		{
			service.AddScoped<IProductService, ProductService>();
		}
	}
}
