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
        private IFileIOServices<List<ToDoModel>> fileIOServices;

        private ObservableCollectionEx<ToDoModel> todoList;

        private readonly CollectionViewSource list = new CollectionViewSource();
        public ICollectionView List => list?.View;

        public ObservableCollectionEx<ToDoModel> TodoList
        {
            get => todoList;
            set
            {
                Set(ref todoList, value, nameof(TodoList));
                list.Source = value;
                list.View.Refresh();
               
            }
        }
        #region Конструктор

        public ToDoViewModel()
        {
            TodoList = GetSaveData();
            todoList.CollectionChanged += TodoList_CollectionChanged;
            
            list.Filter += List_Filter;


        }


        #endregion

        private void TodoList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            fileIOServices.SaveData(TodoList.ToList());
            ProgressBarProgress = ProgressBarProgresPercent();
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

        private int ProgressBarProgresPercent()
        {
            if (TodoList.Count == 0) return 1;
            var chekedCount = TodoList.Count(x => x.IsDone == true);
            return chekedCount * 100 / TodoList.Count;
        }
        #endregion

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
                OnPropertyChanged(nameof(TodoList));
                
                list.View.Refresh();
                OnPropertyChanged(nameof(List));
            }
        }
        #endregion
        private void List_Filter(object sender, FilterEventArgs e)
        {
            var item = e.Item;
            var text = TaskFilter;
            if (string.IsNullOrWhiteSpace(text)) return;
            if (text.Length>1)
                e.Accepted = false;
        }



        #endregion

        #region Вспомогательные методы
        private ObservableCollectionEx<ToDoModel> GetSaveData()
        {
            fileIOServices = new FileIOServices<List<ToDoModel>>("data.json");
            var obserrModelList = fileIOServices.LoadData();
            return new ObservableCollectionEx<ToDoModel>(obserrModelList);
        }

        #endregion
    }
}
