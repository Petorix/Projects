using MyFitnessApp.Models;
using MyFitnessApp.Services;
using MyFitnessApp.Views;
using Plugin.LocalNotifications;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace MyFitnessApp.ViewModels
{
    public class MeVM : BaseUserVM
    {
        public Command UserTapCommand { get; }
        public Command GoalTapCommand { get; }
        public Command ProgressTapCommand { get; }

        public bool Notifications_Goals
        {
            get => goalNotify;
            set
            {
                goalNotify = value;
                OnPropertyChanged("Notifications_Goals");
                OnGoalNotifyChange();
            }
        }

        public bool Notifications_Meals
        {
            get => trackMealNotify;
            set
            {
                trackMealNotify = value;
                OnPropertyChanged("Notifications_Meals");
                OnMealNotifyChange();
            }
        }

        public bool Notifications_Fitness
        {
            get => trackFitnessNotify;
            set
            {
                trackFitnessNotify = value;
                OnPropertyChanged("Notifications_Fitness");
                OnFitnessNotifyChange();
            }
        }

        public MeVM()
        {
            Title = "Me";

            UserTapCommand = new Command(OnUserTap);
            GoalTapCommand = new Command(OnGoalTap);
            ProgressTapCommand = new Command(OnProgressTap);
        }

        private void OnGoalNotifyChange()
        {
            if (Notifications_Meals == true)
            {
                MainGoal goal = (MainGoal)GeneralGoal;
                var gstr = goal.ToString().ToLower();
                CrossLocalNotifications.Current.Show("You have a goal to keep", $"Remember you're trying to {gstr} weight! Keep working hard!", 101, DateTime.Now.AddDays(1));
            }
            else
            {
                CrossLocalNotifications.Current.Cancel(101);
            }
        }

        private void OnMealNotifyChange()
        {
            if (Notifications_Meals == true)
            {
                CrossLocalNotifications.Current.Show("MyFitnessApp", "Remember to log your meals today!", 102, DateTime.Now.AddDays(1).AddMinutes(1));
            }
            else
            {
                CrossLocalNotifications.Current.Cancel(102);
            }
        }

        private void OnFitnessNotifyChange()
        {
            if (Notifications_Fitness == true)
            {
                CrossLocalNotifications.Current.Show("MyFitnessApp", "Remember to log your workouts for the day!", 103, DateTime.Now.AddDays(1).AddMinutes(2));
            }
            else
            {
                CrossLocalNotifications.Current.Cancel(103);
            }
        }

        private async void OnUserTap()
        {
            await Shell.Current.GoToAsync(nameof(UserDetailView));
        }

        private async void OnGoalTap()
        {
            await Shell.Current.GoToAsync(nameof(GoalDetailView));
        }

        private async void OnProgressTap()
        {
            await Shell.Current.GoToAsync(nameof(HistoryView));
        }
    }
}
