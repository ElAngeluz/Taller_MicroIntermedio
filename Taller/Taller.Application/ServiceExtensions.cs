using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Taller.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}