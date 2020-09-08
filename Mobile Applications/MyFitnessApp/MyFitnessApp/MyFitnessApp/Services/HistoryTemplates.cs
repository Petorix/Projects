using MyFitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace MyFitnessApp.Services
{
    public class HistoryTemplates : DataTemplateSelector
    {
        public DataTemplate WeightHistoryTemplate { get; set; }
        public DataTemplate MealHistoryTemplate { get; set; }
        public DataTemplate ExerciseHistoryTemplate { get; set; }
        public DataTemplate TotalHistoryTemplate { get; set; }
        public DataTemplate ErrorTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            DataTemplate dt = ErrorTemplate;

            var t = item.GetType();

            if (typeof(WeightHistory).Equals(t))
                dt = WeightHistoryTemplate;
            if (typeof(Meals).Equals(t))
                dt = MealHistoryTemplate;
            if (typeof(Exercises).Equals(t))
                dt = ExerciseHistoryTemplate;
            if (typeof(TotalHistory).Equals(t))
                dt = TotalHistoryTemplate;

            return dt;
        }
    }
}
