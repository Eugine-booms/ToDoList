using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace ToDoList.ViewModel
{
    [MarkupExtensionReturnType(typeof(DateFilterViewModel))]
    internal class DateFilterViewModel:Base.ViewModelBase
    {
        public DateFilterViewModel(Base.ViewModelBase mainViewModel)
        {
            MainViewModel = mainViewModel ?? throw new ArgumentNullException(nameof(mainViewModel));
        }

        internal Base.ViewModelBase MainViewModel { get; }


    }
}
