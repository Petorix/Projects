using SQLite;
using System;

namespace MyFitnessApp.Models
{
    public class TotalHistory
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public DateTime EntryDate { get; set; }
        public int CaloriesTotal { get; set; }

        //Make sure todays totalhistory entry gets updated each time the user updates their goal
        public int CaloriesGoal { get; set; }
    }
}
