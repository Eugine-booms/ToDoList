using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BL.Models.Interfaces;

namespace ToDoList.Services.Interface
{
  internal  interface IRepositary <T>  where T :  IEntity   
    {
        void Add(T item);
        bool Remove(T item);
        void Update( T item);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Save();
    }
}
