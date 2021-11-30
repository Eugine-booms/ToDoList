using System;
using System.Collections.Generic;
using ToDoList.Model;

namespace ToDoList.Services
{
    public class TaskManager
    {
        private readonly ToDoRepositary _tasks;

        public TaskManager(ToDoRepositary tasks)
        {
            _tasks = tasks ?? throw new ArgumentNullException(nameof(tasks));
        }

        public IEnumerable<ToDoTask> Tasks => _tasks.GetAll();
        public void Update(ToDoTask task) => _tasks.Update( task);
        internal int GetID() => _tasks.LastID;
        internal bool CreateNewTask(List<ToDoTask> tasks)
        {
            if (tasks is null) throw new ArgumentNullException(nameof(tasks));
            foreach (var task in tasks)
            {
                _tasks.Add(task);
            }
            
            return true;
        }

        internal bool CreateNewTask(ToDoTask task)
        {
            if (task is null) throw new ArgumentNullException(nameof(task));
               _tasks.Add(task);
            return true;
        }

        internal void RemoveTask(ToDoTask selectedTask)
        {
            _tasks.Remove(selectedTask);
        }
    }
}
