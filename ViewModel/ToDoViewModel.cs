using System.ComponentModel;
using System.Linq;
using ToDoList.ViewModel.Base;
using System.Windows.Data;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Windows.Markup;
using ToDoList.Model;
using ToDoList.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;
using ToDoList.Command.Base;

namespace ToDoList.ViewModel
{


    [MarkupExtensionReturnType(typeof(ToDoViewModel))]
    public class ToDoViewModel : ViewModelBase
    {

        /// <summary>
        /// Модель полоски фильтров
        /// </summary>
        private FiltratorViewModel filtrator;
        /// <summary>
        /// Главная коллекция объектов расширенная ObservableCollection следящая за изменением своих свойств
        /// </summary> 
        private ObservableCollectionEx<ToDoTask> todoList;
        public ObservableCollectionEx<ToDoTask> TodoList
        {
            get => todoList;
            set
            {
                Set(ref todoList, value, nameof(TodoList));
            }
        }
        /// <summary>
        /// Прокси между V и VM
        /// </summary>
        private readonly CollectionViewSource list = new CollectionViewSource();
        /// <summary>
        /// Менеджер модели
        /// </summary>
        private readonly TaskManager _taskManager;

        public ICollectionView List => list?.View;

        //----------------------------------------------------


        //ToDo Обработать удаление 
        #region selectedTask : ToDoTask  - Выбранная задача
        ///<summary> Выбранная задача
        private ToDoTask _selectedTask;
        ///<summary> Выбранная задача
        public ToDoTask SelectedTask
        {
            get => _selectedTask;
            set
            {
                Set(ref _selectedTask, value);
            }
        }
        #endregion

        #region selectedTaskIndex : int  - Индекс Выбранной задачи
        ///<summary> Индекс Выбранной задачи
        private int _selectedTaskIndex;
        ///<summary> Индекс Выбранной задачи
        public int SelectedTaskIndex
        {
            get => _selectedTaskIndex;
            set => Set(ref _selectedTaskIndex, value);
        }
        #endregion

        #region Конструктор

        public ToDoViewModel(FiltratorViewModel filtrator, TaskManager taskManager)
        {
            Filtrator = filtrator;
            _taskManager = taskManager;
            Filtrator.MainViewModel = this;
           
            list.Source = _taskManager.Tasks;
            //------------------------------------
            //ToDo Ведет себя странно. Надо подумать как удалить
            TodoList = new ObservableCollectionEx<ToDoTask>(_taskManager.Tasks.ToList());
            TodoList.PropertyChangedEx += TodoList_PropertyChangedEx;
             //------------------------------------------------------------------
            list.Filter += MainListFilter;
            Filtrator.PropertyChanged += (t, e) => list.View.Refresh();
        }

        #endregion

       
        
        #region Полоска фильтров 
         /// <summary>
         /// Действия при изменении коллекции
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void TodoList_PropertyChangedEx(object sender, PropertyChangedEventArgs e)
        {
            var fsdfds = TodoList;
            if (!(sender is ToDoTask task)) return;
            _taskManager.Update(task);
            ProgressBarProgress = ProgressBarProgresPercent();
        }
        /// <summary>
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
            var taskCount = _taskManager.Tasks.Count();
            if (taskCount == 0) return 0;
            var chekedCount = _taskManager.Tasks.Count(x => x.IsDone == true);
            return chekedCount * 100 / taskCount;
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
            if (!(e.Item is ToDoTask model)) return;
            if (Filtrator.IsTrue(model)) return; //проходит ли модель через все установленые фильтры
            e.Accepted = false;
        }
        #endregion

        #region Команды
        #region Команда добавление строчки
       // private ICommand addTaskCommand;
        

        public ICommand AddTaskCommand => new LambdaCommand(OnAddTaskCommandExicut, CanAddTaskCommandExicuted);

        private bool CanAddTaskCommandExicuted(object arg) => true;
        

        private void OnAddTaskCommandExicut(object obj)
        {
            var id = _taskManager.GetID();
            var newtask= new ToDoTask() { Id = id++, Text = string.Empty };
            TodoList.Add(newtask);
            _taskManager.CreateNewTask(newtask);
            //OnPropertyChanged(nameof(TodoList));
            list.View.Refresh();
        }
        #endregion
        #region Команда удаления строчки
      //  private ICommand delTaskCommand;
        public ICommand DelTaskCommand => new LambdaCommand(OnDelTaskCommandExicut, CanDelTaskCommandExicuted);

        private bool CanDelTaskCommandExicuted(object arg) => SelectedTask != null;
        

        private void OnDelTaskCommandExicut(object obj)
        {
            var selectedTaskIndex = SelectedTaskIndex;
            TodoList.Remove(SelectedTask);
            _taskManager.RemoveTask(SelectedTask);
            //OnPropertyChanged(nameof(TodoList));
            list.View.Refresh();
            
            SelectedTaskIndex = selectedTaskIndex;

        }

        #endregion

        #endregion

    }
}
