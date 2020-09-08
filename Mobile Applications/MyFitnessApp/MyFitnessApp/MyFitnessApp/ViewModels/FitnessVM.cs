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
    public class FitnessVM : BaseVM
    {
        public Command WorkoutCommand { get; }
        public Command<Exercises> ExerciseTapCommand { get; }

        public ObservableCollection<Exercises> WorkoutsEntries { get; }

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

        public FitnessVM()
        {
            Title = "Fitness";
            WorkoutsEntries = new ObservableCollection<Exercises>();

            WorkoutCommand = new Command(OnWorkout);
            ExerciseTapCommand = new Command<Exercises>(OnItemTap);
        }

        public async void OnAppearing()
        {
            LoadWorkouts();

            GoalCal = await UserCalculations.TodaysCalories();
            FoodCal = await App.dm.GetTodaysMealCalories();
            ExerCal = await App.dm.GetTodaysExerciseCalories();
            RemainCal = GoalCal - FoodCal + ExerCal;
        }

        private async void LoadWorkouts()
        {
            try
            {
                WorkoutsEntries.Clear();

                var items = await App.dm.GetTodaysWorkouts();
                foreach (var item in items)
                {
                    WorkoutsEntries.Add(item);
                }

                CollectionViewHeight = (WorkoutsEntries.Count * 40) * 2;
            }
            catch
            {
                Debug.WriteLine("Error refreshing eaten meals collection.");
            }
        }

        private async void OnWorkout()
        {
            await Shell.Current.GoToAsync(nameof(ExerciseView));
        }

        private async void OnItemTap(Exercises ex)
        {
            var result = await Application.Current.MainPage.DisplayActionSheet($"{ex.ExerciseName}", "Cancel", null, "Edit", "Delete");

            if (result == "Edit")
            {
                await Shell.Current.GoToAsync($"{nameof(ExerciseDetailView)}?{nameof(ExerciseDetailVM.ExerciseID)}={ex.ID}");
            }

            if (result == "Delete")
            {
                var isDeleted = await App.dm.DeleteExerciseEntry(ex.EH_FK, ex.Calories);

                if (isDeleted)
                    LoadWorkouts();
            }
        }
    }
}
