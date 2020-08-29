using MyFitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyFitnessApp.ViewModels
{
    public class GoalDetailVM : BaseUserVM
    {
        public Command EntryChanged { get; }

        public GoalDetailVM()
        {
            user = new User();

            Title = "My Goal";
            EntryChanged = new Command(OnEntryChanged);
        }

        private void OnEntryChanged()
        {
            App.dm.UpdateUser(user);
        }
    }
}
