using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Services.Interface;
using ToDoList.BL.Models.Interfaces;
using ToDoList.BL.Services;
using ToDoList.Model.Mock;
using ToDoList.Model;
using ToDoList.BL.Models;

namespace ToDoList.Services.Base
{

    public abstract class RepositoryInMemory : IRepositary<ToDoTask>

    {
        
        protected static IFileIOServices<List<ToDoTask>> _fileIO = new FileIOServices<List<ToDoTask>>(App.CurrentDirectory+"\\Resources\\data.json");
        private List<ToDoTask> _items;

        private int _lastId = 0;
        internal int LastID { get => _lastId; }
        protected RepositoryInMemory() : this(_fileIO.LoadData()) { }

        protected RepositoryInMemory(IEnumerable<ToDoTask> items)
        {
            _items = new List<ToDoTask>();
            foreach (var item in items)
            {    item.Id = ++_lastId;
                _items.Add(item );
            }
        }

        public void Add(ToDoTask item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (_items.Contains(item)) return;
            item.Id = ++_lastId;
            _items.Add(item);
            Save();

        }

        public ToDoTask Get(int id) => _items.FirstOrDefault(x => x.Id == id);
        public ToDoTask Get(ToDoTask item) => _items.FirstOrDefault(x => x == item);

        public IEnumerable<ToDoTask> GetAll() => _items;

        public bool Remove(ToDoTask item)
        {
            if(_items.Contains(item))
            _items.Remove(item);
            this.Save();
            return true;
        }

        public void Update(ToDoTask item)
        {
            if (item == null) throw new ArgumentException(nameof(item));
            var db_item = this.Get(item);
            if (db_item == null) throw new InvalidOperationException("Редактируемый элемент не найден в репозитарии");
            Update(item, db_item);

        }
        protected abstract void Update(ToDoTask source, ToDoTask distanation);

        public void Save()
        {
            _fileIO.SaveData(_items);
        }
    }
}
