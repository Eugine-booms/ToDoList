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
using System.Windows.Markup;
using ToDoList.Servises;
using ToDoList.Servises.Interface;

namespace ToDoList.ViewModel
{


    [MarkupExtensionReturnType(typeof(ToDoViewModel))]
    public class ToDoViewModel : ViewModelBase
    {
        /// <summary>
        /// Менеджер загрузки
        /// </summary>
        public IServiceIO FileIO { get; }
        
        //private IFileIOServices<List<ToDoModel>> fileIOServices;
        /// <summary>
        /// Модель полоски фильтров
        /// </summary>
        private FiltratorViewModel filtrator;
        /// <summary>
        /// Главная коллекция объектов расширенная ObservableCollection следящая за изменением своих свойств
        /// </summary> 
        private ObservableCollectionEx<ToDoModel> todoList;
        public ObservableCollectionEx<ToDoModel> TodoList
        {
            get => todoList;
            set
            {
                Set(ref todoList, value, nameof(TodoList));
                list.Source = value;
            }
        }
        /// <summary>
        /// Прокси между V и VM
        /// </summary>
        private readonly CollectionViewSource list = new CollectionViewSource();
        public ICollectionView List => list?.View;

        //----------------------------------------------------





        #region Конструктор

        public ToDoViewModel(FiltratorViewModel filtrator, IServiceIO servis)
        {
            Filtrator = filtrator;
            Filtrator.MainViewModel = this;


            FileIO = servis;
            FileIO.SetPath("data.json");
            TodoList = GetSaveData();
            TodoList.CollectionChanged += TodoList_CollectionChanged;
            list.Filter += MainListFilter;
            Filtrator.PropertyChanged += (t, e) => list.View.Refresh();
        }


        #endregion

        /// <summary>
        /// Действия при изменении коллекции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TodoList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            FileIO.SaveData(TodoList.ToList());
            ProgressBarProgress = ProgressBarProgresPercent();
        }
        #region Полоска фильтров 
        // <summary>
        /// VM Для полоски фильтров
        /// </summary>

        
        public FiltratorViewModel Filtrator
        {
            get => filtrator;
            set
            {
                Set(ref filtrator, value, nameof(Filtrator));
            }
        }
        #endregion

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

        /// <summary>
        /// Сортировка главного листа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainListFilter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is ToDoModel model)) return;
            if (Filtrator.IsTrue(model)) return; //проходит ли модель через все установленые фильтры
            e.Accepted = false;
        }
        #endregion

        #region Вспомогательные методы
        /// <summary>
        /// Загрузка данных из менеджера загрузки
        /// </summary>
        /// <returns></returns>
        private ObservableCollectionEx<ToDoModel> GetSaveData()
        {
            var obserrModelList = FileIO.LoadData();
            return new ObservableCollectionEx<ToDoModel>(obserrModelList);
        }

        #endregion
    }
}
