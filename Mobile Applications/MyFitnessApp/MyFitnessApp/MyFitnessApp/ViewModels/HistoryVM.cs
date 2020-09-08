using MyFitnessApp.Models;
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyFitnessApp.ViewModels
{
    public class HistoryVM : BaseVM
    {
        public Command ExportCommand { get; }

        private Expression<Func<WeightHistory, bool>> whPredicate;
        private Expression<Func<MealsHistory, bool>> mhPredicate;
        private Expression<Func<ExercisesHistory, bool>> ehPredicate;
        private Expression<Func<TotalHistory, bool>> thPredicate;

        public ObservableCollection<object> CurrentDisplay { get; }
        public ObservableCollection<ChartDataPoint> ChartDisplay { get; set; }

        //Entries
        private int collectionViewHeight;
        public int CollectionViewHeight
        {
            get => collectionViewHeight;
            set
            {
                SetProperty(ref collectionViewHeight, value);
            }
        }

        private List<string> itemFilterList;
        public List<string> ItemFilterList
        {
            get => itemFilterList;
            set => SetProperty(ref itemFilterList, value);
        }

        private int itemSelectedIndex = -1;
        public int ItemSelectedIndex
        {
            get => itemSelectedIndex;
            set
            {
                if (value == -1)
                {
                    SetProperty(ref dateSelectedIndex, value);
                    return;
                }

                if (value != itemSelectedIndex)
                {
                    SetProperty(ref itemSelectedIndex, value);
                    LoadSelection();
                }
            }
        }

        private List<string> dateFilterList;
        public List<string> DateFilterList
        {
            get => dateFilterList;
            set => SetProperty(ref dateFilterList, value);
        }

        private int dateSelectedIndex = -1;
        public int DateSelectedIndex
        {
            get => dateSelectedIndex;
            set
            {
                if(value == -1)
                {
                    SetProperty(ref dateSelectedIndex, value);
                    return;
                }

                if(value != dateSelectedIndex)
                {
                    SetProperty(ref dateSelectedIndex, value);
                    LoadPredicate();
                    LoadSelection();
                }
            }
        }

        private string entryDescriptor;
        public string EntryDescriptor
        {
            get => entryDescriptor;
            set
            {
                var detail = $"{value} entries";
                SetProperty(ref entryDescriptor, detail);
            }
        }

        //Chart bindings
        private string numericalAxisName;
        public string NumericalAxisName
        {
            get => numericalAxisName;
            set => SetProperty(ref numericalAxisName, value);
        }

        private int numericalAxisInterval;
        public int NumericalAxisInterval
        {
            get => numericalAxisInterval;
            set => SetProperty(ref numericalAxisInterval, value);
        }

        private int numericalAxisMin;
        public int NumericalAxisMin
        {
            get => numericalAxisMin;
            set => SetProperty(ref numericalAxisMin, value);
        }

        public HistoryVM()
        {
            Title = "Progress and history";
            CurrentDisplay = new ObservableCollection<object>();
            ChartDisplay = new ObservableCollection<ChartDataPoint>();

            ItemFilterList = new List<string>
            {
                "Weight",
                "Meals",
                "Exercises",
                "Total"
            };
            DateFilterList = new List<string>
            {
                "Week",
                "Month",
                "Year",
                "All"
            };

            ExportCommand = new Command(OnExport);
        }

        public void OnAppearing()
        {
            DateSelectedIndex = 0;
            ItemSelectedIndex = 0;
        }

        private void LoadSelection()
        {
            switch (ItemSelectedIndex)
            {
                case 0:
                    WeightSelection();
                    break;
                case 1:
                    MealSelection();
                    break;
                case 2:
                    ExerciseSelection();
                    break;
                case 3:
                    TotalSelection();
                    break;
                default:
                    break;
            }
        }

        private void LoadPredicate()
        {
            switch (DateSelectedIndex)
            {
                case 0:
                    WeekPredicates();
                    break;
                case 1:
                    MonthPredicates();
                    break;
                case 2:
                    YearPredicates();
                    break;
                case 3:
                    AllPredicates();
                    break;
                default:
                    break;
            }
        }

        private void WeekPredicates()
        {
            var lastWeek = DateTime.Today.AddDays(-7);

            whPredicate = x => x.EntryDate >= lastWeek;
            mhPredicate = x => x.EntryDate >= lastWeek;
            ehPredicate = x => x.EntryDate >= lastWeek;
            thPredicate = x => x.EntryDate >= lastWeek;

        }

        private void MonthPredicates()
        {
            var lastMonth = DateTime.Today.AddMonths(-1);

            whPredicate = x => x.EntryDate >= lastMonth;
            mhPredicate = x => x.EntryDate >= lastMonth;
            ehPredicate = x => x.EntryDate >= lastMonth;
            thPredicate = x => x.EntryDate >= lastMonth;
        }

        private void YearPredicates()
        {
            var lastYear = DateTime.Today.AddYears(-1);

            whPredicate = x => x.EntryDate >= lastYear;
            mhPredicate = x => x.EntryDate >= lastYear;
            ehPredicate = x => x.EntryDate >= lastYear;
            thPredicate = x => x.EntryDate >= lastYear;
        }

        private void AllPredicates()
        {
            whPredicate = null;
            mhPredicate = null;
            ehPredicate = null;
            thPredicate = null;
        }

        private async void WeightSelection()
        {
            CurrentDisplay.Clear();
            ChartDisplay.Clear();

            var items = await App.dm.GetWeightHistories(whPredicate);
            int lowestWeight = 999;

            foreach (WeightHistory item in items)
            {
                if (item.Weight < lowestWeight)
                    lowestWeight = item.Weight;

                CurrentDisplay.Add(item);
                ChartDisplay.Add(new ChartDataPoint(item.EntryDate.Date.ToString("d"), item.Weight));
            }

            NumericalAxisName = "Weight";
            NumericalAxisInterval = 5;

            if (lowestWeight - 50 < 0)
                NumericalAxisMin = 0;
            else
                NumericalAxisMin = lowestWeight - 50;

            EntryDescriptor = $"{CurrentDisplay.Count} weight";
            CollectionViewHeight = (CurrentDisplay.Count * 41) * 2;
        }

        private async void MealSelection()
        {
            CurrentDisplay.Clear();
            ChartDisplay.Clear();

            var items = await App.dm.GetMealsHistory(mhPredicate);
            int lowestCal = 9999;

            foreach (Meals item in items)
            {
                if (item.Calories < lowestCal)
                    lowestCal = item.Calories;

                CurrentDisplay.Add(item);
                ChartDisplay.Add(new ChartDataPoint(item.Entry.Date.ToString("d"), item.Calories));
            }

            NumericalAxisName = "Calories";
            NumericalAxisInterval = 5;

            if (lowestCal - 300 < 0)
                NumericalAxisMin = 0;
            else
                NumericalAxisMin = lowestCal - 300;

            EntryDescriptor = $"{CurrentDisplay.Count} meal";
            CollectionViewHeight = (CurrentDisplay.Count * 51) * 2;
        }

        private async void ExerciseSelection()
        {
            CurrentDisplay.Clear();
            ChartDisplay.Clear();

            var items = await App.dm.GetExercisesHistory(ehPredicate);

            foreach (Exercises item in items)
            {
                CurrentDisplay.Add(item);
                ChartDisplay.Add(new ChartDataPoint(item.Entry.Date.ToString("d"), item.Calories));
            }

            NumericalAxisName = "Calories";
            NumericalAxisInterval = 5;
            NumericalAxisMin = 0;

            EntryDescriptor = $"{CurrentDisplay.Count} exercise";
            CollectionViewHeight = (CurrentDisplay.Count * 51) * 2;
        }

        private async void TotalSelection()
        {
            CurrentDisplay.Clear();
            ChartDisplay.Clear();

            var items = await App.dm.GetTotalHistories(thPredicate);
            int lowestCal = 9999;

            foreach (TotalHistory item in items)
            {
                if (item.CaloriesTotal < lowestCal)
                    lowestCal = item.CaloriesTotal;

                CurrentDisplay.Add(item);

                if(item.CaloriesTotal < 0)
                    ChartDisplay.Add(new ChartDataPoint(item.EntryDate.Date.ToString("d"), 0));
                else
                    ChartDisplay.Add(new ChartDataPoint(item.EntryDate.Date.ToString("d"), item.CaloriesTotal));
            }

            NumericalAxisName = "Calories";
            NumericalAxisInterval = 5;
            if (lowestCal - 300 < 0)
                NumericalAxisMin = 0;
            else
                NumericalAxisMin = lowestCal - 300;

            EntryDescriptor = $"{CurrentDisplay.Count} total";
            CollectionViewHeight = (CurrentDisplay.Count * 51) * 2;
        }

        private async void OnExport()
        {
            var currentType = CurrentDisplay.First().GetType();

            var fn = $"{currentType}_Export.csv";
            var file = Path.Combine(FileSystem.CacheDirectory, fn);
            var header = "";
            var content = "";

            if (typeof(WeightHistory).Equals(currentType))
            {
                foreach (WeightHistory item in CurrentDisplay)
                {
                    header = $"EntryDate,Weight{Environment.NewLine}";
                    content += $"{item.EntryDate},{item.Weight}{Environment.NewLine}";
                }
            }
            if (typeof(Meals).Equals(currentType))
            {
                foreach (Meals item in CurrentDisplay)
                {
                    header = $"MealName,Calories,EntryDate{Environment.NewLine}";
                    content += $"{item.MealName},{item.Calories},{item.Entry}{Environment.NewLine}";
                }
            }
            if (typeof(Exercises).Equals(currentType))
            {
                foreach (Exercises item in CurrentDisplay)
                {
                    header = $"ExerciseName,Calories,EntryDate{Environment.NewLine}";
                    content += $"{item.ExerciseName},{item.Calories},{item.Entry}{Environment.NewLine}";
                }
            }
            if (typeof(TotalHistory).Equals(currentType))
            {
                foreach (TotalHistory item in CurrentDisplay)
                {
                    header = $"EntryDate,CaloriesTotal,CaloriesGoal{Environment.NewLine}";
                    content += $"{item.EntryDate},{item.CaloriesTotal},{item.CaloriesGoal}{Environment.NewLine}";
                }
            }

            File.WriteAllText(file, header + content);

            await Share.RequestAsync(new ShareFileRequest
            {
                Title = "Export Request",
                File = new ShareFile(file)
            });
        }
    }
}
