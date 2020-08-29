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
    public class ExerciseVM : BaseVM
    {
        public Command<Exercises> MenuIconCommand { get; }
        public Command ExerciseDetailCommand { get; }
        public Command<Exercises> WorkoutCommand { get; }
        public Command SearchCommand { get; }

        public ObservableCollection<Exercises> Workouts { get; }

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
                ExerciseListUpdate();
            }
        }

        public ExerciseVM()
        {
            Title = "Exercises";
            Workouts = new ObservableCollection<Exercises>();


            MenuIconCommand = new Command<Exercises>(OnMenuIconPopup);
            ExerciseDetailCommand = new Command(NewExerciseDetail);
            WorkoutCommand = new Command<Exercises>(OnWorkout);
            SearchCommand = new Command(ExerciseListUpdate);
        }

        public void OnAppearing()
        {
            ExerciseListUpdate();
        }

        private async void ExerciseListUpdate()
        {
            try
            {
                Workouts.Clear();

                var items = await App.dm.GetListedExercises(SearchString);

                foreach (var item in items)
                {
                    Workouts.Add(item);
                }

                CollectionViewHeight = (Workouts.Count * 40) * 2;
            }
            catch
            {
                Debug.WriteLine("Error refreshing workouts collection.");
            }
        }

        private async void NewExerciseDetail()
        {
            string NEW_EX = "-1";
            await Shell.Current.GoToAsync($"{nameof(ExerciseDetailView)}?{nameof(ExerciseDetailVM.ExerciseID)}={NEW_EX}");
        }
        
        private async void OnMenuIconPopup(Exercises ex)
        {
            var result = await Application.Current.MainPage.DisplayActionSheet($"{ex.ExerciseName}", "Cancel", null, "Edit", "Delete");

            if (result == "Cancel")
            {
                return;
            }

            if (result == "Edit")
            {
                await Shell.Current.GoToAsync($"{nameof(ExerciseDetailView)}?{nameof(ExerciseDetailVM.ExerciseID)}={ex.ID}");
            }

            if (result == "Delete")
            {
                var isDeleted = await App.dm.DeleteExercise(ex);

                if (isDeleted)
                    ExerciseListUpdate();
            }
        }

        private async void OnWorkout(Exercises ex)
        {
            App.dm.InsertExerciseEntry(ex.ID, ex.Calories, await UserCalculations.TodaysCalories());

            await Shell.Current.GoToAsync("..");
        }
    }
}
