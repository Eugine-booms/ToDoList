using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Model
{
    public class ObservableCollectionEx<T> : ObservableCollection<T> where T : INotifyPropertyChanged
    {
        // this collection also reacts to changes in its components' properties
        public event PropertyChangedEventHandler PropertyChangedEx;
        public ObservableCollectionEx() : base()
        {
            CollectionChanged += new NotifyCollectionChangedEventHandler(ObservableCollectionEx_CollectionChanged);
           
        }

        public ObservableCollectionEx(List<T> list)
        {
            CollectionChanged += new NotifyCollectionChangedEventHandler(ObservableCollectionEx_CollectionChanged);
            foreach (var item in list)
            {
                Add(item);
            }
        }

        void ObservableCollectionEx_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
               
                case NotifyCollectionChangedAction.Remove:
                    foreach (T item in e.OldItems)
                    {
                        //Removed items
                        item.PropertyChanged -= EntityViewModelPropertyChanged;
                    }
                    break;
                case NotifyCollectionChangedAction.Add:
                    foreach (T item in e.NewItems)
                    {
                        //Added items
                        item.PropertyChanged += EntityViewModelPropertyChanged;
                    }
                    break;
                default:
                    break;
            }
        }

        private void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChangedEx?.Invoke(sender, e);
        }
    }

}