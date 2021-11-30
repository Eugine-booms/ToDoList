using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Model;
using ToDoList.Services.Base;

namespace ToDoList.Services
{
    public class ToDoRepositary : RepositoryInMemory  
    {
        protected override void Update(ToDoTask source, ToDoTask distanation)
        {
            
            distanation.CreationDate = source.CreationDate;
            distanation.IsDone = source.IsDone;
            distanation.Text = source.Text;
            distanation.Deadline = source.Deadline;
            //TODO нужны ли они тут, или придется делать копирование рекурсией
            distanation.SubTask = source.SubTask;
            Save();
        }
    }
}
