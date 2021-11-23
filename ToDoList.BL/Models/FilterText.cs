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
        private bool isDone=true;
        private string text;
        private string endData;
        private bool isNotDone=true;
        public string CreationData
        {
            get => creationData;
            set
            {
                Set(ref creationData, value, nameof(CreationData));
            }
        }
        public bool ShowIsDone
        {
            get => isDone;
            set
            {
                Set(ref isDone, value, nameof(ShowIsDone));
            }
        }
        public bool ShowNotIsDone
        {
            get => isNotDone;
            set
            {
                Set(ref isNotDone, value, nameof(ShowNotIsDone));
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
