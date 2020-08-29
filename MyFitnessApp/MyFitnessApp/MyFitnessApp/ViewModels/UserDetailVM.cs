using MyFitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace MyFitnessApp.ViewModels
{
    public class UserDetailVM : BaseUserVM
    {
        public Command EntryChanged { get; }
        public Command StartingWeightChanged { get; }
        public Command CurrentWeightChanged { get; }

        public UserDetailVM()
        {
            user = new User();

            Title = "Me";
            EntryChanged = new Command(OnEntryChanged);
            StartingWeightChanged = new Command(UpdateStartingWeight);
            CurrentWeightChanged = new Command(InsertCurrentWeight);
        }

        private void OnEntryChanged()
        {
            App.dm.UpdateUser(user);
        }

        private async void UpdateStartingWeight()
        {
            var weightHistories = await App.dm.GetAllWeightEntries();

            var firstHistory = weightHistories.First();
            firstHistory.Weight = int.Parse(StartingWeight);

            App.dm.UpdateWeightEntry(firstHistory);

            OnEntryChanged();
        }

        private void InsertCurrentWeight()
        {
            App.dm.InsertWeightEntry(int.Parse(CurrentWeight));
            OnEntryChanged();
        }
    }
}
