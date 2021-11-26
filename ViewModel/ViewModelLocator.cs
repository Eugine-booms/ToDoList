using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Markup;

namespace ToDoList.ViewModel
{
    
    public   class ViewModelLocator 
    {
        
        public ViewModelLocator()
        {
        }

        public ToDoViewModel MainWindowViewModel
        { 
            get 
            { 
                return App.Host.Services.GetRequiredService<ToDoViewModel>(); 
            } 
        }
    }
}
