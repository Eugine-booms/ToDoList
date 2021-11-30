using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using ToDoList.Services.Helpers;
using ToDoList.ViewModel.Base;

namespace ToDoList.ViewModel
{
    [MarkupExtensionReturnType(typeof(DateFilterViewModel))]
    public class DateFilterViewModel : ViewModelBase
    {
        public DateFilterViewModel()
        {
        }
        public FiltratorViewModel MainViewModel { get; internal set; }
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
                Set(ref checkboxMonth, value, nameof(CheckboxMonth));
                if (value)
                {
                    CheckBoxDay = false;
                    CheckboxWeek = false;
                }
            }
        }

        public DateTimeRange GetDateTimeInterval()
        {
            if (checkBoxDay)
                return new DateTimeRange(SelectedDate, selectedDate.AddDays(1));
            if (checkboxWeek)
                return new DateTimeRange(SelectedDate, SelectedDate.AddDays(7));
            if (checkboxMonth)
                return new DateTimeRange(selectedDate, SelectedDate.AddDays(30));
            return new DateTimeRange(DateTime.MinValue, DateTime.MaxValue);
        }
    }
}
