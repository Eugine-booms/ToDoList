using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToDoList.BL.Services;

namespace ToDoList.Model.Mock
{
   public class DataMock <T> : IFileIOServices<List<T>>   where T : new ()
    {
        public List<T> LoadData()
        {
            return Enumerable.Range(1, 10).Select(x => new T()).ToList();
        }

        public void SaveData(List<T> data)
        {
            MessageBox.Show("Method- Save");
        }

        public bool SetPath(string path)
        {
            throw new NotImplementedException();
        }
    }
}
