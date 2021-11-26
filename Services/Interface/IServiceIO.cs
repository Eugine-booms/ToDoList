using System.Collections.Generic;
using ToDoList.BL.Models;

namespace ToDoList.Servises.Interface
{
    public interface IServiceIO
    {
        List<ToDoModel> LoadData();
        void SetPath(string path);
        void SaveData(List<ToDoModel> data);
    }
}