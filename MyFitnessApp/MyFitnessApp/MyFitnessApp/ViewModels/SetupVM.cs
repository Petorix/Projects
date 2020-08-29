using MyFitnessApp.Models;
using MyFitnessApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace MyFitnessApp.ViewModels
{
    public class SetupVM : BaseUserVM
    {
        public Command Start { get; }
        public Command Finish { get; }
        public Command CreateDummyData { get; }

        private bool firstScreen;
        public bool FirstScreen
        {
            get => firstScreen;
            set => SetProperty(ref firstScreen, value);
        }

        private bool secondScreen;
        public bool SecondScreen
        {
            get => secondScreen;
            set => SetProperty(ref secondScreen, value);
        }

        private bool errorShow;
        public bool ErrorShow
        {
            get => errorShow;
            set => SetProperty(ref errorShow, value);
        }

        private string errorText;
        public string ErrorText
        {
            get => errorText;
            set => SetProperty(ref errorText, value);
        }

        public SetupVM()
        {
            user = new User();

            //Bindings
            Title = "Setup";
            FirstScreen = true;
            SecondScreen = false;

            //Commands
            Start = new Command(StartPage);
            Finish = new Command(SaveUser);
            CreateDummyData = new Command(AddSampleData);
        }

        private void StartPage()
        {
            FirstScreen = false;
            SecondScreen = true;
        }

        private async void SaveUser()
        {
            var result = FormCheck();

            if (result.Count > 0)
            {
                string processResult = "Please enter valid entries for: ";
                for (var i = 0; i < result.Count; i++)
                {
                    if (i == result.Count -1)
                    {
                        processResult += result[i] + ".";
                    }
                    else
                    {
                        processResult += result[i] + ", ";
                    }
                }

                ErrorText = processResult;
                ErrorShow = true;
                return;
            }

            StartingWeight = CurrentWeight;
            StartingDate = DateTime.Today;
            GoalNotify = false;
            TrackMealNotify = false;
            TrackFitnessNotify = false;

            //Adding data 
            ContentSetup();
            await App.dm.InsertUser(user);
            App.dm.InsertWeightEntry(user.StartingWeight);

            await Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "1");
            Application.Current.MainPage = new AppShell();
        }

        private List<string> FormCheck()
        {
            var result = new List<string>();

            if (UserName == "")
                result.Add("Username");
            if (CurrentWeight == "")
                result.Add("Current Weight");
            if (Height == "")
                result.Add("Height");
            if (Gender == -1)
                result.Add("Gender");
            if (StartingFitnessLevel == -1)
                result.Add("Current Activity Level");
            if (WorkoutTimeFrame == -1)
                result.Add("Exercise Time");
            if (GeneralGoal == -1)
                result.Add("Main Goal");
            if (GoalWeight == "" && GeneralGoal != (int)MainGoal.Maintain)
                result.Add("Goal Weight");
            if (Birthday == DateTime.Today)
                result.Add("Birthday");
            if (GoalDate == DateTime.Today)
                result.Add("Goal Date");
            return result;
        }

        private async void AddSampleData()
        {
            User fakeUser = new User()
            {
                UserName = "Sample Data",
                StartingWeight = 170,
                StartingFitnessLevel = (int)ActivityLevels.Medium,
                CurrentWeight = 170,
                GeneralGoal = (int)MainGoal.Lose,
                GoalWeight = 160,
                WorkoutTimeFrame = 1,
                Gender = 0,
                Height = 5.10,
                StartingDate = DateTime.Today,
                Birthday = new DateTime(1990, 10, 15),
                GoalDate = new DateTime(2020, 12, 25),
                GoalNotify = false,
                GymAccess = false,
                TrackMealNotify = false,
                TrackFitnessNotify = false
            };

            await App.dm.InsertUser(fakeUser);

            ExternalContent ex1 = new ExternalContent()
            {
                Title = "Having a hard time keeping your goal?",
                Description = "Don't worry, we've all been there",
                HTML = "<iframe width='370' height='290' src='https://www.youtube.com/embed/Z63w5PefxTQ' frameborder='0' allow='accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture' allowfullscreen> </iframe>"

            };

            ExternalContent ex2 = new ExternalContent()
            {
                Title = "Back Pain",
                Description = "Weak glutes and an underactive gluteus maximus muscle are one of the fastest ways to experience low back pain",
                HTML = "<iframe width='370' height='290' src='https://www.youtube.com/embed/NhlVYy1wkKQ' frameborder='0' allow='accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>"
            };

            await App.dm.InsertExternalContent(ex1);
            await App.dm.InsertExternalContent(ex2);

            Meals m1 = new Meals()
            {
                MealName = "Banana",
                Calories = 105,
                Carbs = 27,
                Fat = 0,
                Protein = 1,
                MealType = 0
            };

            Meals m2 = new Meals()
            {
                MealName = "Egg",
                Calories = 78,
                Carbs = 0,
                Fat = 5,
                Protein = 6,
                MealType = 0
            };

            Meals m3 = new Meals()
            {
                MealName = "Muffin",
                Calories = 278,
                Carbs = 0,
                Fat = 5,
                Protein = 6,
                MealType = 0
            };

            Meals m4 = new Meals()
            {
                MealName = "Apple",
                Calories = 95,
                Carbs = 25,
                Fat = 0,
                Protein = 0,
                MealType = 0
            };

            await App.dm.InsertMeal(m1);
            await App.dm.InsertMeal(m2);
            await App.dm.InsertMeal(m3);
            await App.dm.InsertMeal(m4);

            Exercises e1 = new Exercises()
            {
                ExerciseName = "Pushups",
                Calories = 20,
                Intensity = (int)Intensity.Medium,
                BodyArea = (int)BodyArea.Chest
            };

            Exercises e2 = new Exercises()
            {
                ExerciseName = "Pullups",
                Calories = 20,
                Intensity = (int)Intensity.Medium,
                BodyArea = (int)BodyArea.Back
            };

            Exercises e3 = new Exercises()
            {
                ExerciseName = "Run",
                Calories = 80,
                Intensity = (int)Intensity.MediumHigh,
                BodyArea = (int)BodyArea.Legs
            };

            Exercises e4 = new Exercises()
            {
                ExerciseName = "Sprint",
                Calories = 100,
                Intensity = (int)Intensity.VeryHigh,
                BodyArea = (int)BodyArea.Legs
            };

            await App.dm.InsertExercise(e1);
            await App.dm.InsertExercise(e2);
            await App.dm.InsertExercise(e3);
            await App.dm.InsertExercise(e4);

            await Application.Current.MainPage.DisplayAlert("", "Create dummy data finished", "Continue");

            await Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "1");
            Application.Current.MainPage = new AppShell();
        }


        private async void ContentSetup()
        {
            ExternalContent ex1 = new ExternalContent()
            {
                Title = "Having a hard time keeping your goal?",
                Description = "Don't worry, we've all been there",
                HTML = "<iframe width='370' height='290' src='https://www.youtube.com/embed/Z63w5PefxTQ' frameborder='0' allow='accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture' allowfullscreen> </iframe>"

            };

            ExternalContent ex2 = new ExternalContent()
            {
                Title = "Back Pain",
                Description = "Weak glutes and an underactive gluteus maximus muscle are one of the fastest ways to experience low back pain",
                HTML = "<iframe width='370' height='290' src='https://www.youtube.com/embed/NhlVYy1wkKQ' frameborder='0' allow='accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>"
            };

            await App.dm.InsertExternalContent(ex1);
            await App.dm.InsertExternalContent(ex2);
        }
    }
}
