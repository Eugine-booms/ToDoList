using Microsoft.Extensions.DependencyInjection;
using ToDoList.Model;
using ToDoList.Services.Base;
using ToDoList.Services.Interface;

namespace ToDoList.Services
{
    internal static class Registrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<ToDoRepositary>();
            services.AddSingleton<TaskManager>();

            
            return services;
        }
    }
}
