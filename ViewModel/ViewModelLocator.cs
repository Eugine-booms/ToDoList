using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Markup;

namespace ToDoList.ViewModel
{
    [MarkupExtensionReturnType(typeof(ViewModelLocator))]
    public   class ViewModelLocator : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
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
