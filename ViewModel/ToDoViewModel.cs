using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using ToDoList.BL.Models;
using ToDoList.BL.Services;
using ToDoList.ViewModel.Base;
using System.Windows.Data;
using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using ToDoList.BL.Models.Services;

namespace ToDoList.ViewModel
{
    internal class ToDoViewModel : ViewModelBase
    {
        private readonly IFileIOServices <List<ToDoModel>> fileIOServices;

        private ObservableCollectionEx<ToDoModel> todoList;
        public ObservableCollectionEx<ToDoModel> TodoList 
        { 
            get => todoList; 
            set 
            { 
                Set(ref todoList, value, nameof(TodoList));
                OnPropertyChanged(nameof(TodoList));
            } 
        }
       
        public ToDoViewModel()
        {
            fileIOServices = new FileIOServices<List<ToDoModel>>("data.json");
            var obserrModelList = fileIOServices.LoadData();
            if (obserrModelList is null)
                TodoList = new ObservableCollectionEx<ToDoModel>();
            else
                TodoList = new ObservableCollectionEx<ToDoModel>(obserrModelList);
            todoList.CollectionChanged += TodoList_CollectionChanged;
           
        }

        private void TodoList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            fileIOServices.SaveData(TodoList.ToList());
            
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
            if (TodoList.Count == 0) return 1;
            var chekedCount = TodoList.Count(x=>x.IsDone==true);
            return chekedCount * 100 / TodoList.Count;
        }


        #region  Сортировка 

        #region TaskFilter : string  - TaskFilter
        ///<summary> TaskFilter
        private string _taskFilter;
        ///<summary> TaskFilter
        public string TaskFilter
        {
            get => _taskFilter;
            set
            {
                if (!Set(ref _taskFilter, value)) return;
                list.View.Refresh();
            }
        }
        #endregion
        private CollectionViewSource list = new CollectionViewSource();
        public ICollectionView List => list?.View;


        private void ToDoViewSource_Filter(object sender, FilterEventArgs e)
        {
            e.Accepted = true;
            if (!(e.Item is ToDoModel model))
            {
                e.Accepted = false;
                return;
            }
            if (model.Text is null)
            {
                e.Accepted = false;
                return;
            }
            var searchText = TaskFilter;
            if (string.IsNullOrWhiteSpace(searchText)) return;
            if (model.Text.ToLower().Contains(searchText.Trim(' ').ToLower())) return;
            e.Accepted = false;
        }

        #endregion



    }
}
