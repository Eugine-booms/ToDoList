using System.Collections.ObjectModel;
using ToDoList.BL.Models;

namespace ToDoList.BL.Services
{
    public interface IFileIOServices<T>
    {
        T LoadData();
        void SaveData(T data);
    }
}