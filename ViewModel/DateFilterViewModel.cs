using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace ToDoList.ViewModel
{
    [MarkupExtensionReturnType(typeof(DateFilterViewModel))]
    public class DateFilterViewModel : Base.ViewModelBase
    {
        public DateFilterViewModel(FiltratorViewModel mainViewModel)
        {
            MainViewModel = mainViewModel ?? throw new ArgumentNullException(nameof(mainViewModel));
        }
        public FiltratorViewModel MainViewModel { get; set; }


        private DateTime selectedDate = DateTime.Now;
        private bool checkBoxDay;
        private bool checkboxWeek;
        private bool checkboxMonth;

        public DateTime SelectedDate
        {
            get => selectedDate;
            set => Set(ref selectedDate, value, nameof(SelectedDate));
        }
        public bool CheckBoxDay
        {
            get => checkBoxDay;
            set
            {
                Set(ref checkBoxDay, value, nameof(CheckBoxDay));
                if (value)
                {
                    CheckboxWeek = false;
                    CheckboxMonth = false;
                }
            }
        }
        public bool CheckboxWeek
        {
            get => checkboxWeek;
            set
            {
                Set(ref checkboxWeek, value, nameof(CheckboxWeek));
                if (value)
                {
                    CheckBoxDay = false;
                    CheckboxMonth = false;
                }
            }
        }
        public bool CheckboxMonth
        {
            get => checkboxMonth; set
            {
                Set(ref checkboxMonth, value);
                if (value)
                {
                    CheckBoxDay = false;
                    CheckboxWeek = false;
                }
            }
        }
    }
}
