using SQLite;
using System;

namespace MyFitnessApp.Models
{
    public class Exercises
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string ExerciseName { get; set; }
        public int Calories { get; set; }
        public int Intensity { get; set; }
        public int BodyArea { get; set; }
        public int EH_FK { get; set; }
        public DateTime Entry { get; set; }
    }
}
