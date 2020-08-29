using MyFitnessApp.Models;
using MyFitnessApp.Services;
using MyFitnessApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace MyFitnessApp.ViewModels
{
    public class NutritionVM : BaseVM
    {
        public Command EatCommand { get; }
        public Command<Meals> MealTapCommand { get; }

        public ObservableCollection<Meals> EatenMeals { get; }

        private int collectionViewHeight;
        public int CollectionViewHeight
        {
            get => collectionViewHeight;
            set
            {
                SetProperty(ref collectionViewHeight, value);
            }
        }

        private int goalCal;
        public int GoalCal
        {
            get => goalCal;
            set => SetProperty(ref goalCal, value);
        }

        private int foodCal;
        public int FoodCal
        {
            get => foodCal;
            set => SetProperty(ref foodCal, value);
        }

        private int exerCal;
        public int ExerCal
        {
            get => exerCal;
            set => SetProperty(ref exerCal, value);
        }

        private int remainCal;
        public int RemainCal
        {
            get => remainCal;
            set => SetProperty(ref remainCal, value);
        }

        public NutritionVM()
        {
            Title = "Nutrition";
            EatenMeals = new ObservableCollection<Meals>();

            EatCommand = new Command(OnEat);
            MealTapCommand = new Command<Meals>(OnItemTap);
        }

        public async void OnAppearing()
        {
            LoadEatenMeals();

            GoalCal = await UserCalculations.TodaysCalories();
            FoodCal = await App.dm.GetTodaysMealCalories();
            ExerCal = await App.dm.GetTodaysExerciseCalories();
            RemainCal = GoalCal - FoodCal + ExerCal;
        }

        private async void LoadEatenMeals()
        {
            try
            {
                EatenMeals.Clear();

                var items = await App.dm.GetTodaysMeals();
                foreach (var item in items)
                {
                    EatenMeals.Add(item);
                }

                CollectionViewHeight = (EatenMeals.Count * 40) * 2;
            }
            catch
            {
                Debug.WriteLine("Error refreshing eaten meals collection.");
            }
        }

        private async void OnEat(object obj)
        {
            await Shell.Current.GoToAsync(nameof(MealsView));
        }

        private async void OnItemTap(Meals meal)
        {
            var result = await Application.Current.MainPage.DisplayActionSheet($"{meal.MealName}", "Cancel", null, "Edit", "Delete");

            if (result == "Edit")
            {
                await Shell.Current.GoToAsync($"{nameof(MealDetailView)}?{nameof(MealDetailVM.MealID)}={meal.ID}");
            }

            if (result == "Delete")
            {
                var isDeleted = await App.dm.DeleteMealEntry(meal.MH_FK, meal.Calories);

                if(isDeleted)
                    LoadEatenMeals();
            }
        }
    }
}
