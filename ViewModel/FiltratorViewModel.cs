using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using ToDoList.BL.Models;

namespace ToDoList.ViewModel
{
    [MarkupExtensionReturnType(typeof(FiltratorViewModel))]
    public class FiltratorViewModel : Base.ViewModelBase
    {
        public ToDoViewModel MainViewModel { get; internal set; }

        private string creationData;
        private bool isDone = true;
        private string text;
        private string endData;
        private bool isNotDone = true;
        private DateFilterViewModel dateFilter;
        private DateFilterViewModel deadLineFilter;




        public FiltratorViewModel(ToDoViewModel mainViewModel)
        {
            MainViewModel = mainViewModel ?? throw new ArgumentNullException(nameof(mainViewModel));
            DateFilter = new DateFilterViewModel(this);
            DeadLineFilter = new DateFilterViewModel(this);

            DateFilter.PropertyChanged += DateFilter_PropertyChanged;
            deadLineFilter.PropertyChanged += DeadLineFilter_PropertyChanged;

        }

        private void DeadLineFilter_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(DateFilter));
        }

        private void DateFilter_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(DateFilter));
        }

        public DateFilterViewModel DeadLineFilter { get => deadLineFilter; set => Set(ref deadLineFilter, value); }
        public DateFilterViewModel DateFilter
        {
            get => dateFilter;
            set
            {
                if (dateFilter is null)
                    dateFilter = new DateFilterViewModel(this);
                Set(ref dateFilter, value, nameof(DateFilter));
            }
        }

        public string CreationData
        {
            get => creationData;
            set
            {
                Set(ref creationData, value, nameof(CreationData));
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
        public string EndData
        {
            get => endData;
            set
            {
                Set(ref endData, value, nameof(EndData));
            }
        }

       

        public bool IsTrue(ToDoModel model)
        {
            var result = new bool[5];
            if (!string.IsNullOrWhiteSpace(this.CreationData))
            {
                result[0] = true;

            }
            if (!string.IsNullOrWhiteSpace(Text))
            {
                result[1] = true;
                if (model.Text.ToLower().Contains(Text.Trim(' ').ToLower()))
                {
                    result[1] = false;
                }
            }
            if (!string.IsNullOrWhiteSpace(EndData))
            {
                result[2] = true;

            }
            result[3] = true;
            if (ShowIsDone && ShowNotIsDone
                || ShowIsDone && model.IsDone
                || ShowNotIsDone && (!model.IsDone))
            {
                result[3] = false;
            }
            return result.All(x => x == false); ;
        }

    }
}

