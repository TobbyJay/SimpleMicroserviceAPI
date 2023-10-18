using SimpleMicroserviceAPI.Data;

namespace SimpleMicroserviceAPI.Extensions
{
	public static class ServiceExtension
	{
		public static void RegisterOrderServices(this IServiceCollection services)
		{
			services.AddScoped<IOrderService,OrderService>();
		}
	}
}
