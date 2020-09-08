using MyFitnessApp.Models;
using MyFitnessApp.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace MyFitnessApp.ViewModels
{
    public class HomeVM : BaseVM
    {
        public Command BackToSetup { get; }

        private User mainUser;

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

        private string generalGoal;
        public string GeneralGoal
        {
            get => generalGoal;
            set => SetProperty(ref generalGoal, value);
        }

        private string goalAmount;
        public string GoalAmount
        {
            get => goalAmount;
            set => SetProperty(ref goalAmount, value);
        }

        private decimal weightProgress;
        public decimal WeightProgress
        {
            get => weightProgress;
            set => SetProperty(ref weightProgress, value);
        }

        private int calorieProgress;
        public int CalorieProgress
        {
            get => calorieProgress;
            set => SetProperty(ref calorieProgress, value);
        }

        public ObservableCollection<ExternalContent> ExternalContents { get; }

        private int collectionViewHeight;
        public int CollectionViewHeight
        {
            get => collectionViewHeight;
            set
            {
                SetProperty(ref collectionViewHeight, value);
            }
        }

        public HomeVM()
        {
            ExternalContents = new ObservableCollection<ExternalContent>();

            Title = "Home";
            GeneralGoal = "Loading big content";
            GoalAmount = "loading big content";

            BackToSetup = new Command(OnButtonClick);
        }

        public async void OnAppearing()
        {
            LoadContent();

            mainUser = await App.dm.GetUser();

            GoalCal = await UserCalculations.TodaysCalories();
            FoodCal = await App.dm.GetTodaysMealCalories();
            ExerCal = await App.dm.GetTodaysExerciseCalories();
            RemainCal = GoalCal - FoodCal + ExerCal;
            CalorieProgress = 0;

            MainGoal sel = (MainGoal)mainUser.GeneralGoal;

            if ((MainGoal)mainUser.GeneralGoal == MainGoal.Maintain)
            {
                if (mainUser.StartingWeight > mainUser.CurrentWeight)
                    GeneralGoal = "Gain";
                if (mainUser.StartingWeight < mainUser.CurrentWeight)
                    GeneralGoal = "Lose";
                if (mainUser.StartingWeight == mainUser.CurrentWeight)
                    GeneralGoal = "Maintaining";
            }
            else
            {
                GeneralGoal = Enum.GetName(sel.GetType(), sel);
            }
            

            var lastSunday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            var thisSaturday = lastSunday.AddDays(6);

            var allEntries = await App.dm.GetAllWeightEntries();
            var weekEntries = allEntries.FindAll(x => x.EntryDate >= lastSunday && x.EntryDate <= thisSaturday);
            var weekStartWeight = mainUser.StartingWeight;

            //Does it give the list with the latest date first or last?
            if (allEntries.FindLast(x => x.EntryDate < lastSunday) != null)
            {
                weekStartWeight = allEntries.FindLast(x => x.EntryDate < lastSunday).Weight;
            }
            var weeksGoal = UserCalculations.WeeklyWeightGoal(GoalCal, weekStartWeight, mainUser.Gender);

            if (weekEntries.Count == 0)
            {
                WeightProgress = 0;
            }
            else
            {
                var lastEntry = weekEntries.Last().Weight;

                if (weeksGoal != 0)
                    WeightProgress = Math.Abs(((weekStartWeight - lastEntry) / weeksGoal) * 100);
                else
                    WeightProgress = 100;
            }


            if (weeksGoal != 0)
                GoalAmount = $"{weeksGoal} lbs";
            else
                GoalAmount = "";

            var weekAgo = DateTime.Now.AddDays(-7);
            var items = await App.dm.GetTotalHistories(x => x.EntryDate >= weekAgo);
            foreach (TotalHistory item in items)
            {
                if (item.CaloriesTotal <= GoalCal)
                {
                    CalorieProgress += 15;
                }
            }
        }

        public async void LoadContent()
        {
            try
            {
                var items = await App.dm.GetExternalContent();
                if (items == null)
                {
                    Debug.WriteLine("Items came back as null");
                    return;
                }


                ExternalContents.Clear();
                foreach (var item in items)
                {
                    ExternalContents.Add(item);
                }

                CollectionViewHeight = (ExternalContents.Count * 125) * 2;
            }
            catch
            {
                Debug.WriteLine("Error refreshing collection.");
            }
        }

        public async void OnButtonClick()
        {
            //App.dm.ResetMealHistoryTable();
            //App.dm.ResetTotalHistory();
            App.dm.RESET_EVERYTHING();

            await Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "0");
            await Shell.Current.GoToAsync($"//Setup");
        }
    }
}
