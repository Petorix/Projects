using MyFitnessApp.Models;
using MyFitnessApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MyFitnessApp.ViewModels
{
    public class BaseUserVM : BaseVM
    {
        protected User user;

        //User Info
        private string userName = "";
        public string UserName
        {
            get => userName;
            set
            {
                SetProperty(ref userName, value);
                user.UserName = value;
            }
        }

        private int gender = -1;
        public int Gender
        {
            get => gender;
            set
            {
                SetProperty(ref gender, value);
                user.Gender = value;
            }
        }

        private string startingWeight = "";
        public string StartingWeight
        {
            get => startingWeight;
            set
            {
                SetProperty(ref startingWeight, value);
                if (value == "" || value == null)
                    user.StartingWeight = 0;
                else
                    user.StartingWeight = int.Parse(value);
            }
        }

        private string currentWeight = "";
        public string CurrentWeight
        {
            get => currentWeight;
            set
            {
                SetProperty(ref currentWeight, value);
                if (value == "" || value == null)
                    user.CurrentWeight = 0;
                else
                    user.CurrentWeight = int.Parse(value);
            }
        }

        private int startingFitnessLevel = -1;
        public int StartingFitnessLevel
        {
            get => startingFitnessLevel;
            set
            {
                SetProperty(ref startingFitnessLevel, value);
                user.StartingFitnessLevel = value;
            }
        }

        private int workoutTimeFrame = -1;
        public int WorkoutTimeFrame
        {
            get => workoutTimeFrame;
            set
            {
                SetProperty(ref workoutTimeFrame, value);
                user.WorkoutTimeFrame = value;
            }
        }

        private string height = "";
        public string Height
        {
            get => height;
            set
            {
                SetProperty(ref height, value);
                if (value == "" || value == null)
                    user.Height = 0;
                else
                    user.Height = double.Parse(value);
            }
        }

        private DateTime startingDate = DateTime.Today;
        public DateTime StartingDate
        {
            get => startingDate;
            set
            {
                SetProperty(ref startingDate, value);
                user.StartingDate = value;
            }
        }

        private DateTime birthday = DateTime.Today;
        public DateTime Birthday
        {
            get => birthday;
            set
            {
                SetProperty(ref birthday, value);
                user.Birthday = value;
            }
        }

        private bool gymAccess = false;
        public bool GymAccess
        {
            get => gymAccess;
            set
            {
                SetProperty(ref gymAccess, value);
                user.GymAccess = value;
            }
        }


        //Goal Info
        private int generalGoal = -1;
        public int GeneralGoal
        {
            get => generalGoal;
            set
            {
                SetProperty(ref generalGoal, value);
                user.GeneralGoal = value;
            }
        }

        private string goalWeight = "";
        public string GoalWeight
        {
            get => goalWeight;
            set
            {
                SetProperty(ref goalWeight, value);
                if (value == "" || value == null)
                    user.GoalWeight = 0;
                else
                    user.GoalWeight = int.Parse(value);
            }
        }

        private DateTime goalDate = DateTime.Today;
        public DateTime GoalDate
        {
            get => goalDate;
            set
            {
                SetProperty(ref goalDate, value);
                user.GoalDate = value;
            }
        }


        //Preferences
        protected bool goalNotify = false;
        public bool GoalNotify
        {
            get => goalNotify;
            set
            {
                SetProperty(ref goalNotify, value);
                user.GoalNotify = value;
            }
        }

        protected bool trackMealNotify = false;
        public bool TrackMealNotify
        {
            get => trackMealNotify;
            set
            {
                SetProperty(ref trackMealNotify, value);
                user.TrackMealNotify = value;
            }
        }

        protected bool trackFitnessNotify = false;
        public bool TrackFitnessNotify
        {
            get => trackFitnessNotify;
            set
            {
                SetProperty(ref trackFitnessNotify, value);
                user.TrackFitnessNotify = value;
            }
        }


        //Lists
        private List<string> genderList;
        public List<string> GenderList
        {
            get => genderList;
            set => SetProperty(ref genderList, value);
        }

        private List<string> activityLevelList;
        public List<string> ActivityLevelList
        {
            get => activityLevelList;
            set => SetProperty(ref activityLevelList, value);
        }

        private List<string> workoutTimeFrameList;
        public List<string> WorkoutTimeFrameList
        {
            get => workoutTimeFrameList;
            set
            {
                SetProperty(ref workoutTimeFrameList, value);
            }
        }

        private List<string> generalGoalList;
        public List<string> GeneralGoalList
        {
            get => generalGoalList;
            set
            {
                var itemList = new List<string>();
                foreach (string item in value)
                {
                    itemList.Add("To " + item + " weight");
                }
                SetProperty(ref generalGoalList, itemList);
            }
        }

        public void OnAppearing()
        {
            LoadLists();
            LoadUser();
        }

        private void LoadLists()
        {
            GenderList = Enumerations.EnumToList(typeof(Gender));
            ActivityLevelList = Enumerations.EnumToList(typeof(ActivityLevels));
            WorkoutTimeFrameList = new List<string>()
            {
                "20 minutes or less",
                "30 minutes",
                "45 minutes",
                "1 hour or more"
            };
            GeneralGoalList = Enumerations.EnumToList(typeof(MainGoal));
            
        }

        private async void LoadUser()
        {
            try
            {
                user = await App.dm.GetUser();

                //user info
                UserName = user.UserName;
                Gender = user.Gender;
                StartingWeight = user.StartingWeight.ToString();
                CurrentWeight = user.CurrentWeight.ToString();
                StartingFitnessLevel = user.StartingFitnessLevel;
                WorkoutTimeFrame = user.WorkoutTimeFrame;
                Height = user.Height.ToString();
                StartingDate = user.StartingDate;
                Birthday = user.Birthday;
                GymAccess = user.GymAccess;

                //goal
                GeneralGoal = user.GeneralGoal;
                GoalWeight = user.GoalWeight.ToString();
                GoalDate = user.GoalDate;

                //preferences
                GoalNotify = user.GoalNotify;
                TrackMealNotify = user.TrackMealNotify;
                trackFitnessNotify = user.TrackFitnessNotify;
            }
            catch
            {
                Debug.WriteLine("LoadUser failed.");

                user = new User();
            }
            
        }
    }
}
