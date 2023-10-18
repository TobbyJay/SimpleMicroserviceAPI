using Microsoft.Extensions.DependencyInjection;

namespace Extensions
{
	public static class Class1
	{
		public static IServiceCollection RegisterServices(this IServiceCollection services)
		{
			return services;
		}
	}
}