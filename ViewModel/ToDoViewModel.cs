using System.ComponentModel;
using System.Linq;
using ToDoList.BL.Models;
using ToDoList.BL.Services;
using ToDoList.ViewModel.Base;

namespace ToDoList.ViewModel
{
    internal class ToDoViewModel : ViewModelBase
    {
        private readonly IFileIOServices<BindingList<ToDoModel>> fileIOServices;

        private BindingList<ToDoModel> todoList = new BindingList<ToDoModel>();
        public BindingList<ToDoModel> TodoList { get => todoList; set => Set(ref todoList, value, nameof(TodoList)); }

        public ToDoViewModel()
        {
            fileIOServices = new FileIOServices<BindingList<ToDoModel>>("data.json");
            todoList=fileIOServices.LoadData();
            todoList.ListChanged += TodoList_ListChanged;
        }

        // ToDO: Привязать статус бар прогресс бар к разности дел - завершенные
        private void TodoList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded
                || e.ListChangedType == ListChangedType.ItemDeleted
                || e.ListChangedType == ListChangedType.ItemChanged
                || e.ListChangedType == ListChangedType.ItemMoved)
            {
                if (sender is BindingList<ToDoModel> model)
                {
                    ProgressBarProgress = ProgressBarProgresPercent();
                    fileIOServices.SaveData(model);
                }
            }
        }


        #region ProgressBarProgress : int  - Процент заполнения прогрессбара
        ///<summary> Процент заполнения прогрессбара
        private int _ProgressBarProgress;
        ///<summary> Процент заполнения прогрессбара
        public int ProgressBarProgress
        {
            get => ProgressBarProgresPercent();
            set => Set(ref _ProgressBarProgress, value);
        }
        #endregion

        private int ProgressBarProgresPercent()
        {
            var chekedCount = TodoList.Count(x=>x.IsDone==true);
            return chekedCount * 100 / TodoList.Count;
        }


        #region text : string  - Text
        ///<summary> Text
        private string _text;
        ///<summary> Text
        public string Text
        {
            get => _text;
            set => Set(ref _text, value);
        }
        #endregion








    }
}
