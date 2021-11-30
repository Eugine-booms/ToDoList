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
            PropertyChanged += ObservableCollectionEx_PropertyChanged;
        }

        private void ObservableCollectionEx_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                default:
                    break;
            }
        }

        public ObservableCollectionEx(List<T> list)
        {
            CollectionChanged += new NotifyCollectionChangedEventHandler(ObservableCollectionEx_CollectionChanged);
            PropertyChanged += ObservableCollectionEx_PropertyChanged;
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
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }

        private void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
           
            //This will get called when the property of an object inside the collection changes - note you must make it a 'reset' - dunno why
            //NotifyCollectionChangedEventArgs args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
            //OnCollectionChanged(args);
            PropertyChangedEx?.Invoke(sender, e);
        }
    }

}