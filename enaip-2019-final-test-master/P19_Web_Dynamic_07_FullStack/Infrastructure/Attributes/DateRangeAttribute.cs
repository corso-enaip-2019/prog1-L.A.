using System;
using System.ComponentModel.DataAnnotations;

namespace P19_Web_Dynamic_07_FullStack.Infrastructure.Attributes
{
    public class DateRangeAttribute : ValidationAttribute
    {
        private DateTime _start;

        public DateRangeAttribute(int startYear, int startMonth, int startDay)
        {
            _start = new DateTime(startYear, startMonth, startDay);
        }

        public override bool IsValid(object value)
        {
            return (value is DateTime date) && (_start < date && date < DateTime.Today);

            //if (value is DateTime date)
            //{
            //    return _start < date && date < DateTime.Today;
            //}
            //else
            //{
            //    return false;
            //}
        }
    }
}
