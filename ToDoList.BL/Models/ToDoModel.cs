﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace ToDoList.BL.Models
{
    [Serializable]
    public class ToDoModel : INotifyPropertyChanged
    {


        private bool _isDone;
        private string _text;
        private IEnumerable <ToDoModel> subTask=new List<ToDoModel>();
        private DateTime deadLine = DateTime.Now;

        //TODO реализовать подзадачи

        public IEnumerable<ToDoModel> SubTask
        {
            get => subTask;
            set { subTask = value; OnPropertyChanged(nameof(SubTask)); }
        }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime Deadline
        {
            get => deadLine;
            set
            {
                deadLine = value;
                OnPropertyChanged(nameof(Deadline));
            }
        }
        public bool IsDone
        {
            get => _isDone; set
            {
                if (value) Deadline = DateTime.Now;
                _isDone = value;
                OnPropertyChanged(nameof(IsDone));
            }
        }

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
