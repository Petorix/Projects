using MyFitnessApp.Models;
using MyFitnessApp.Services;
using MyFitnessApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace MyFitnessApp.ViewModels
{
    public class MealsVM : BaseVM
    {
        public Command<Meals> MenuIconCommand { get; }
        public Command MealDetailCommand { get; }
        public Command<Meals> EatCommand { get; }
        public Command SearchCommand { get; }

        private int collectionViewHeight;
        public int CollectionViewHeight
        {
            get => collectionViewHeight;
            set
            {
                SetProperty(ref collectionViewHeight, value);
            }
        }

        private string searchString = "";
        public string SearchString
        {
            get => searchString;
            set
            {
                if (value == searchString)
                    return;

                SetProperty(ref searchString, value);
                MealsListUpdate();
            }
        }

        public ObservableCollection<Meals> Meals { get; }

        public MealsVM()
        {
            Title = "Meals";
            Meals = new ObservableCollection<Meals>();


            MenuIconCommand = new Command<Meals>(OnMenuIconPopup);
            MealDetailCommand = new Command(NewMealDetail);
            EatCommand = new Command<Meals>(OnEat);
            SearchCommand = new Command(MealsListUpdate);
        }

        public void OnAppearing()
        {
            MealsListUpdate();
        }

        private async void MealsListUpdate()
        {
            try
            {
                Meals.Clear();

                var items = await App.dm.GetListedMeals(SearchString);

                foreach (var item in items)
                {
                    Meals.Add(item);
                }

                CollectionViewHeight = (Meals.Count * 40) * 2;
            }
            catch
            {
                Debug.WriteLine("Error refreshing meals collection.");
            }
        }

        private async void NewMealDetail()
        {
            string NEW_MEAL = "-1";
            await Shell.Current.GoToAsync($"{nameof(MealDetailView)}?{nameof(MealDetailVM.MealID)}={NEW_MEAL}");
        }

        private async void OnMenuIconPopup(Meals meal)
        {
            var result = await Application.Current.MainPage.DisplayActionSheet($"{meal.MealName}", "Cancel", null, "Edit", "Delete");

            if (result == "Cancel" )
            {
                return;
            }

            if (result == "Edit")
            {
                await Shell.Current.GoToAsync($"{nameof(MealDetailView)}?{nameof(MealDetailVM.MealID)}={meal.ID}");
            }

            if (result == "Delete")
            {
                var isDeleted = await App.dm.DeleteMeal(meal);

                if (isDeleted)
                    MealsListUpdate();
            }
        }

        private async void OnEat(Meals meal)
        {
            App.dm.InsertMealEntry(meal.ID, meal.Calories, await UserCalculations.TodaysCalories());

            await Shell.Current.GoToAsync("..");
        }

    }
}
