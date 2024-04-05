using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(ServiceExtension).Assembly));

            return services;
        }
    }
}
