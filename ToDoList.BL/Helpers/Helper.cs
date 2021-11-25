using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BL.Models;
using ToDoList.BL.Services;

namespace ToDoList.BL.Helpers
{
  public static class Helper
    {
      public static  bool IsInRange(this DateTime dateToCheck, DateTime startDate, DateTime endDate)
        {
            return dateToCheck >= startDate && dateToCheck <= endDate;
        }
        public static bool IsInRange(this DateTime dateToCheck, DateTimeRange dateTimeRange)
        {
            return dateToCheck >= dateTimeRange.StartDate && dateToCheck <= dateTimeRange.EndDate;
        }

        public static IFileIOServices<List<ToDoModel>> SetPath(this FileIOServices<List<ToDoModel>> fileIO, string path)
        {
            if (fileIO.SetPath(path)) ;
            return fileIO;
        }
    }
}
