using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BL.Models;
using ToDoList.BL.Services;
using ToDoList.Servises.Interface;

namespace ToDoList.Servises
{
    internal class ServiceIO : IServiceIO
    {
        private IFileIOServices<List<ToDoModel>> serv;


        public ServiceIO()
        {
            serv = new FileIOServices<List<ToDoModel>>();
        }

        public List<ToDoModel> LoadData() => serv.LoadData();
        public void SetPath(string path) => serv.SetPath(path);
        public void SaveData(List<ToDoModel> data) => serv.SaveData(data);
    }
}
