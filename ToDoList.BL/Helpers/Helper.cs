﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BL.Models;

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
    }
}
