using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Taller.Application.Interfaces.Repositories;

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