using Microsoft.Extensions.DependencyInjection;

namespace ToDoList.ViewModel
{
    internal class ViewModelLocator
    {
        public ToDoViewModel MainWindowViewModel => App.Host.Services.GetRequiredService<ToDoViewModel>();
    }
}
