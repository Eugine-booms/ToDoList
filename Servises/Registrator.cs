using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BL.Models;
using ToDoList.BL.Services;

namespace ToDoList.Servises
{
    internal static class Registrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IFileIOServices<List<ToDoModel>>, FileIOServices<List<ToDoModel>>>();
            
            return services;
        }
    }
}
