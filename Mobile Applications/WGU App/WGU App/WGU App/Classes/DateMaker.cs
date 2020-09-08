using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WGU_App.Classes
{
    class DateMaker
    {
        private DatePicker startDate;
        private DateTime prevStartDate;
        private DatePicker endDate;
        private DateTime prevEndDate;

        public DateMaker(DateTime start, DateTime end)
        {
            startDate = new DatePicker
            {
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                Date = start,
                IsEnabled = false,
                MinimumDate = start
            };
            prevStartDate = startDate.Date;

            endDate = new DatePicker
            {
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                Date = end,
                IsEnabled = false,
                MinimumDate = startDate.Date.AddDays(1)
            };
            prevEndDate = endDate.Date;

            startDate.DateSelected += (s, e) =>
            {
                endDate.MinimumDate = startDate.Date.AddDays(1);
            };
        }

        public DatePicker GetStart()
        {
            return startDate;
        }

        public DatePicker GetEnd()
        {
            return endDate;
        }

        public void UpdateDates()
        {
            prevStartDate = startDate.Date;
            prevEndDate = endDate.Date;
        }

        public void CheckAndToggle()
        {
            if (prevStartDate != startDate.Date && startDate.IsEnabled)
            {
                startDate.Date = prevStartDate;
            }
            if (prevEndDate != endDate.Date && endDate.IsEnabled)
            {
                endDate.Date = prevEndDate;
            }

            startDate.IsEnabled ^= true;
            endDate.IsEnabled ^= true;
        }
    }
}
