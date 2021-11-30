using System;
using ToDoList.Services.Helpers;

namespace ToDoList.Servises.Helpers
{
    public static class Helper
    {
        public static bool IsInRange(this DateTime dateToCheck, DateTime startDate, DateTime endDate)
        {
            return dateToCheck >= startDate && dateToCheck <= endDate;
        }
        public static bool IsInRange(this DateTime dateToCheck, DateTimeRange dateTimeRange)
        {
            return dateToCheck >= dateTimeRange.StartDate && dateToCheck <= dateTimeRange.EndDate;
        }

    }
}
