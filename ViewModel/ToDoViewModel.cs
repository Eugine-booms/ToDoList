using System.ComponentModel;
using ToDoList.BL.Models;
using ToDoList.BL.Services;
using ToDoList.ViewModel.Base;

namespace ToDoList.ViewModel
{
    internal class ToDoViewModel : ViewModelBase
    {
        private IFileIOServices<BindingList<ToDoModel>> fileIOServices;

        private BindingList<ToDoModel> todoList = new BindingList<ToDoModel>();
        public BindingList<ToDoModel> TodoList { get=>todoList; set=>Set(ref todoList, value, nameof(TodoList)); }

        public ToDoViewModel()
        {
            fileIOServices = new FileIOServices<BindingList<ToDoModel>>("todoList.txt");
            todoList = fileIOServices.LoadData();
            todoList.ListChanged += TodoList_ListChanged;
        }

        private void TodoList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded
                || e.ListChangedType == ListChangedType.ItemDeleted
                || e.ListChangedType == ListChangedType.ItemChanged
                || e.ListChangedType == ListChangedType.ItemMoved)
            {
                if (sender is BindingList<ToDoModel> model)
                {
                    fileIOServices.SaveData(model);
                }
            }
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
