using SQLite;
using System;

namespace MyFitnessApp.Models
{
    public class ExercisesHistory
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public DateTime EntryDate { get; set; }
        public int ExerciseFK { get; set; }
    }
}
