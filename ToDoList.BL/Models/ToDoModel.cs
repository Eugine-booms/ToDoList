using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace ToDoList.BL.Models
{
    [Serializable]
    public class ToDoModel : Interfaces.IEntity 
    {


        public bool IsDone { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeadLine { get; set; }
        public int Id { get; set; }

        //TODO реализовать подзадачи


    }
}
