using Microsoft.Extensions.DependencyInjection;

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
                var mainWindow= App.Host.Services.GetRequiredService<ToDoViewModel>();
                return mainWindow;
            } 
        }
    }
}
