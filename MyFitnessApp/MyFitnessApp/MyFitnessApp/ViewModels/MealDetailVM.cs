using MyFitnessApp.Models;
using MyFitnessApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyFitnessApp.ViewModels
{
    [QueryProperty(nameof(MealID), nameof(MealID))]
    public class MealDetailVM : BaseVM
    {
        private Meals mealDetail;

        private string mealId;
        public string MealID
        {
            get => mealId;
            set
            {
                mealId = value;
                LoadMealId(value);
            }
        }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                mealDetail.MealName = value;
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
                    mealDetail.Calories = 0;
                }
                else
                {
                    mealDetail.Calories = int.Parse(value);
                }
                SetProperty(ref calories, value);
            }
        }

        private string carbs;
        public string Carbs
        {
            get => carbs;
            set
            {
                if (value == "")
                {
                    mealDetail.Carbs = 0;
                }
                else
                {
                    mealDetail.Carbs = int.Parse(value);
                }
                SetProperty(ref carbs, value);
            }
        }

        private string fat;
        public string Fat
        {
            get => fat;
            set
            {
                if (value == "")
                {
                    mealDetail.Fat = 0;
                }
                else
                {
                    mealDetail.Fat = int.Parse(value);
                }
                SetProperty(ref fat, value);
            }
        }

        private string protein;
        public string Protein
        {
            get => protein;
            set
            {
                if (value == "")
                {
                    mealDetail.Protein = 0;
                }
                else
                {
                    mealDetail.Protein = int.Parse(value);
                }
                SetProperty(ref protein, value);
            }
        }

        private int mtype = -1;
        public int MType
        {
            get => mtype;
            set
            {
                mealDetail.MealType = value;
                SetProperty(ref mtype, value);
            }
        }

        private List<string> mealType;
        public List<string> MealType
        {
            get => mealType;
            set
            {
                SetProperty(ref mealType, value);
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

        public MealDetailVM()
        {
            MealType = Enumerations.EnumToList(typeof(Mealtypes));

            CancelCommand = new Command(OnCancel);
            DeleteCommand = new Command(OnDelete);
            SaveCommand = new Command(OnSave, ValidateSave);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private async void LoadMealId(string value)
        {
            if (value == "-1")
            {
                mealDetail = new Meals();
                Title = "Add Meal";

                CancelShow = true;
            }
            else
            {
                mealDetail = await App.dm.GetMeal(int.Parse(value));
                Title = "Edit Meal";

                DeleteShow = true;

                Name = mealDetail.MealName;
                Calories = mealDetail.Calories.ToString();
                Carbs = mealDetail.Carbs.ToString();
                Fat = mealDetail.Fat.ToString();
                Protein = mealDetail.Protein.ToString();
                MType = mealDetail.MealType;
            }            
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(Name)
                && !String.IsNullOrWhiteSpace(Calories)
                && !String.IsNullOrWhiteSpace(Carbs)
                && !String.IsNullOrWhiteSpace(Fat)
                && !String.IsNullOrWhiteSpace(Protein)
                && MType > -1;
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnDelete()
        {
            await App.dm.DeleteMeal(mealDetail);
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            if (MealID == "-1")
            {
                await App.dm.InsertMeal(mealDetail);
            }
            else
            {
                await App.dm.UpdateMeal(mealDetail);
            }
            

            await Shell.Current.GoToAsync("..");
        }
    }
}
