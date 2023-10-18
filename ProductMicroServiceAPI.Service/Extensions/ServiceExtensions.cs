using Microsoft.Extensions.DependencyInjection;
using ProductMicroServiceAPI.Service.Interfaces;
using ProductMicroServiceAPI.Servics.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroServiceAPI.Service.Extensions
{
	public static class ServiceExtensions
	{
		public static IServiceCollection RegisterProductService(this IServiceCollection service)
		{
			return service.AddScoped<IProductService, ProductService>();
		}
	}
}
