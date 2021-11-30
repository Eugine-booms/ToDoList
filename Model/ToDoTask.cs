using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using ToDoList.BL.Models;
using ToDoList.BL.Models.Interfaces;


namespace ToDoList.Model
{
    [Serializable]
    public class ToDoTask : INotifyPropertyChanged, IEntity
    {

        private ToDoModel _model;
        private IEnumerable<ToDoTask> _subTask;
        public ToDoModel Model { get => _model; }
        public ToDoTask()
        { 
            _model = new ToDoModel() {CreationDate=DateTime.Now, DeadLine=DateTime.Now.AddDays(1) }; 
        }
        public ToDoTask(ToDoModel model) : this(model.CreationDate, model.DeadLine, model.IsDone, model.Text, model.Id) { }
        
        public ToDoTask(DateTime creationDate, DateTime deadline, bool isDone, string text, int id)
        {
            _model = new ToDoModel();
            CreationDate = creationDate;
            Deadline = deadline;
            IsDone = isDone;
            Text = text==null? string.Empty : text;
            Id = id;
        }

        //TODO реализовать подзадачи

        public IEnumerable<ToDoTask> SubTask
        {
            get=> _subTask;
            set 
            {      if (!(Equals(_subTask, value)))
                {
                    _subTask = value;
                    OnPropertyChanged(nameof(SubTask));
                }
            }
        }
        public DateTime CreationDate 
        { 
            get => _model.CreationDate;
            set 
            {
                if (!Equals(_model.CreationDate, value))
                {
                    _model.CreationDate = value;
                    OnPropertyChanged(nameof(CreationDate));
                }
            } 
        } 
        public DateTime Deadline
        {
            get => _model.DeadLine;
            set
            {
                if (!Equals(_model.DeadLine, value))
                {
                    _model.DeadLine = value;
                    OnPropertyChanged(nameof(Deadline));
                }
            }
        }
        public bool IsDone
        {
            get => _model.IsDone; set
            {
                if (!Equals(_model.IsDone, value))
                {
                    if (value) Deadline = DateTime.Now;
                    _model.IsDone = value;
                    OnPropertyChanged(nameof(IsDone));
                }
            }
        }

        public string Text
        {
            get => _model.Text;
            set
            {
                if (!Equals(_model.Text, value))
                {
                    _model.Text = value;
                    OnPropertyChanged(nameof(Text));
                }
            }
        }

        public int Id { get  ; set ; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        

    }
}
