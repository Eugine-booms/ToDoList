using System.Windows;
using ToDoList.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ToDoList.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            var sdf = DateTime.Now.ToString("");
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            //if (this.DataContext is ToDoViewModel dc)
            //Create.DataContext = dc.Filtrator.DateFilter;    
        }
    }
}
