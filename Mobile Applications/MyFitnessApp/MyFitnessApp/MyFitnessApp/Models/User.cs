using System;
using SQLite;

namespace MyFitnessApp.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string UserName { get; set; }

        public int StartingWeight { get; set; }
        public int StartingFitnessLevel { get; set; }
        public int CurrentWeight { get; set; }
        public int GeneralGoal { get; set; }
        public int GoalWeight { get; set; }
        public int WorkoutTimeFrame { get; set; }
        public int Gender { get; set; }

        public double Height { get; set; }

        public DateTime StartingDate { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime GoalDate { get; set; }

        public bool GoalNotify { get; set; }
        public bool GymAccess { get; set; }
        public bool TrackMealNotify { get; set; }
        public bool TrackFitnessNotify { get; set; }
    }
}
