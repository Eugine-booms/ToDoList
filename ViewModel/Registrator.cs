using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BL.Models;
using ToDoList.BL.Services;

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
