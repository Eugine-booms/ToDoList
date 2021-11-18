using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BL.Models;

namespace ToDoList.BL.Services
{
    public class FileIOServices<T> : IFileIOServices<T> 
    {
        private readonly string PATH;

        public FileIOServices(string path)
        {
            PATH = path ?? throw new ArgumentNullException(nameof(path));
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            
        }

        public T LoadData()
        {
            var fileExist = File.Exists(PATH);
            if (!fileExist)
            {
                File.CreateText(PATH).Dispose();
                return default(T);
            }
            using (var sr = File.OpenText(PATH))
            {
                
                var input = sr.ReadToEnd();

                var result = JsonConvert.DeserializeObject<T>(input);
                return result;
            }
        }

        public void SaveData(T data)
        {
            using (StreamWriter sw = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(data);
                sw.Write(output);
            }
        }
    }

}
