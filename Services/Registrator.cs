using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BL.Models;
using ToDoList.BL.Services;
using ToDoList.Servises;
using ToDoList.Servises.Interface;

namespace ToDoList.Services
{
    internal static class Registrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IServiceIO, ServiceIO>();
            
            return services;
        }
    }
}
