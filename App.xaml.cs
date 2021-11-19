using System.Globalization;
using System.Windows;

namespace ToDoList
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool IsDesigneMode { get; private set; } = true;
        protected override void OnStartup(StartupEventArgs e)
        {
            IsDesigneMode = false;
            base.OnStartup(e);
        }
    }
}
