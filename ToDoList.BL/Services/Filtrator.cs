using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BL.Models;

namespace ToDoList.BL.Services
{
    public static class Filtrator 
    {
        //private ToDoModel model;
        //private FilterText filterText;

        //public Filtrator(FilterText filterText, ToDoModel model)
        //{
        //    this.model = model ?? throw new ArgumentNullException(nameof(model));
        //    this.filterText = filterText ?? throw new ArgumentNullException(nameof(filterText));
        //}

        public static bool IsTrue(FilterText filterText, ToDoModel model)
        {
            var result = new bool[5];
            if (!string.IsNullOrWhiteSpace(filterText.CreationData))
            {
                result[0] = true;

            }
            if (!string.IsNullOrWhiteSpace(filterText.Text))
            {
                result[1] = true;
                if (model.Text.ToLower().Contains(filterText.Text.Trim(' ').ToLower()))
                {
                    result[1] = false;
                }
            }
            if (!string.IsNullOrWhiteSpace(filterText.EndData))
            {
                result[2] = true;

            }
            result[3] = true;
            if (filterText.ShowIsDone&&filterText.ShowNotIsDone
                ||filterText.ShowIsDone&&model.IsDone
                ||filterText.ShowNotIsDone&&(!model.IsDone))
            {
                result[3] = false;
            }
                return result.All(x => x == false); ;
        }
    }
}
