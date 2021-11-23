using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.BL.Models
{
    public class FilterText : Base.BasePropertyChengModel
    {
        private string creationData;
        private string isDone;
        private string text;
        private string endData;
        public string CreationData
        {
            get => creationData;
            set
            {
                Set(ref creationData, value, nameof(CreationData));
            }
        }
        public string IsDone
        {
            get => isDone;
            set
            {
                Set(ref isDone, value, nameof(IsDone));
            }
        }
        public string Text
        {
            get => text;
            set
            {
                Set(ref text, value, nameof(Text));
            }
        }
        public string EndData
        {
            get => endData;
            set
            {
                Set(ref endData, value, nameof(EndData));
            }
        }

    }
}
