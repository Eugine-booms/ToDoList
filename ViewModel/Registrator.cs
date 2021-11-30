using Microsoft.Extensions.DependencyInjection;

namespace ToDoList.ViewModel
{
    internal static class Registrator
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddSingleton<ToDoViewModel>();
            services.AddTransient<DateFilterViewModel>();
            services.AddSingleton<FiltratorViewModel>();
            return services; 
        }
    }
}
