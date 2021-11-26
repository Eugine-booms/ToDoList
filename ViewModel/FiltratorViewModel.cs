using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using ToDoList.BL.Helpers;
using ToDoList.BL.Models;

namespace ToDoList.ViewModel
{
    [MarkupExtensionReturnType(typeof(FiltratorViewModel))]
    public class FiltratorViewModel : Base.ViewModelBase
    {
        public ToDoViewModel MainViewModel { get; internal set; }

       
        private bool isDone = true;
        private string text;
        private bool isNotDone = true;
        private DateFilterViewModel dateFilter;
        private DateFilterViewModel deadLineFilter;



        public FiltratorViewModel(DateFilterViewModel creationDate, DateFilterViewModel dateOfEnd)
        {
            DateFilter = creationDate;
            DateFilter.MainViewModel=this;
            DeadLineFilter = dateOfEnd;
            deadLineFilter.MainViewModel = this;
            DateFilter.PropertyChanged += DateFilter_PropertyChanged;
            DeadLineFilter.PropertyChanged += DeadLineFilter_PropertyChanged;
            OnPropertyChanged(nameof(DateFilter));
            OnPropertyChanged(nameof(DeadLineFilter));
        }

        private void DateFilter_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(DateFilter));
        }

        private void DeadLineFilter_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(DeadLineFilter));
        }

       
        public DateFilterViewModel DateFilter
        {
            get => dateFilter;
            set
            {
                Set(ref dateFilter, value, nameof(DateFilter));
            }
        }
        public DateFilterViewModel DeadLineFilter
        {
            get => deadLineFilter;
            set
            {
                Set(ref deadLineFilter, value, nameof(DeadLineFilter));
            }
        }
        public bool ShowIsDone
        {
            get => isDone;
            set
            {
                Set(ref isDone, value, nameof(ShowIsDone));
            }
        }
        public bool ShowNotIsDone
        {
            get => isNotDone;
            set
            {
                Set(ref isNotDone, value, nameof(ShowNotIsDone));
            }
        }
        public string Text
        {
            get => text;
            set
            {
                Set(ref text, value, nameof(Text));
            }
        }
        public bool IsTrue(ToDoModel model)
        {
            var result = new bool[5];
           
            if (!string.IsNullOrWhiteSpace(Text))
            {
                result[0] = true;
                if (model.Text.ToLower().Contains(Text.Trim(' ').ToLower()))
                {
                    result[0] = false;
                }
            }
            result[1] = true;
            if (ShowIsDone && ShowNotIsDone
                || ShowIsDone && model.IsDone
                || ShowNotIsDone && (!model.IsDone))
            {
                result[1] = false;
            }
            result[2] = true;
            if (model.CreationDate.IsInRange(DateFilter.GetDateTimeInterval()))
                result[2] = false;
            result[3] = true;
            if (model.Deadline.IsInRange(DeadLineFilter.GetDateTimeInterval()))
                result[3] = false;

            return result.All(x => x == false);
        }

    }
}

