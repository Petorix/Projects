using MyFitnessApp.Models;
using MyFitnessApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyFitnessApp.ViewModels
{
    [QueryProperty(nameof(ExerciseID), nameof(ExerciseID))]
    public class ExerciseDetailVM : BaseVM
    {
        private Exercises exerciseDetail;

        private string exerciseId;
        public string ExerciseID
        {
            get => exerciseId;
            set
            {
                exerciseId = value;
                LoadExerciseID(value);
            }
        }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                exerciseDetail.ExerciseName = value;
                SetProperty(ref name, value);
            }
        }

        private string calories;
        public string Calories
        {
            get => calories;
            set
            {
                if (value == "")
                {
                    exerciseDetail.Calories = 0;
                }
                else
                {
                    exerciseDetail.Calories = int.Parse(value);
                }
                SetProperty(ref calories, value);
            }
        }

        private int intensity = -1;
        public int Intensity
        {
            get => intensity;
            set
            {
                exerciseDetail.Intensity = value;
                SetProperty(ref intensity, value);
            }
        }

        private int bodyArea = -1;
        public int BodyArea
        {
            get => bodyArea;
            set
            {
                exerciseDetail.BodyArea = value;
                SetProperty(ref bodyArea, value);
            }
        }

        private List<string> intensityList;
        public List<string> IntensityList
        {
            get => intensityList;
            set
            {
                SetProperty(ref intensityList, value);
            }
        }

        private List<string> baList;
        public List<string> BAList
        {
            get => baList;
            set
            {
                SetProperty(ref baList, value);
            }
        }

        private bool deleteShow = false;
        public bool DeleteShow
        {
            get => deleteShow;
            set => SetProperty(ref deleteShow, value);
        }

        private bool cancelShow = false;
        public bool CancelShow
        {
            get => cancelShow;
            set => SetProperty(ref cancelShow, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public Command DeleteCommand { get; }

        public ExerciseDetailVM()
        {
            IntensityList = Enumerations.EnumToList(typeof(Intensity));
            BAList = Enumerations.EnumToList(typeof(BodyArea));

            CancelCommand = new Command(OnCancel);
            DeleteCommand = new Command(OnDelete);
            SaveCommand = new Command(OnSave, ValidateSave);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private async void LoadExerciseID(string value)
        {
            if (value == "-1")
            {
                exerciseDetail = new Exercises();
                Title = "Add Exercise";

                CancelShow = true;
            }
            else
            {
                exerciseDetail = await App.dm.GetExercise(int.Parse(value));
                Title = "Edit Exercise";

                DeleteShow = true;

                Name = exerciseDetail.ExerciseName;
                Calories = exerciseDetail.Calories.ToString();
                Intensity = exerciseDetail.Intensity;
                BodyArea = exerciseDetail.BodyArea;
            }
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(Name)
                && !String.IsNullOrWhiteSpace(Calories)
                && Intensity > -1
                && BodyArea > -1;
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnDelete()
        {
            await App.dm.DeleteExercise(exerciseDetail);
            await Shell.Current.GoToAsync("..");
        }


        private async void OnSave()
        {
            if (ExerciseID == "-1")
            {
                await App.dm.InsertExercise(exerciseDetail);
            }
            else
            {
                await App.dm.UpdateExercise(exerciseDetail);
            }


            await Shell.Current.GoToAsync("..");
        }
    }
}
