using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.BL.Models
{
    public class ToDoModel : INotifyPropertyChanged
    {
        private bool _isDone;
        private string _text;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsDone { get => _isDone; set
            {
                _isDone = value;
                OnPropertyChanged(nameof(IsDone));
            }
        }

        public string Text { get => _text; 
            set
            {
               _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
