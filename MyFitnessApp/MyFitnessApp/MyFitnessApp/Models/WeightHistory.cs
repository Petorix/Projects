using SQLite;
using System;

namespace MyFitnessApp.Models
{
    public class WeightHistory
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public DateTime EntryDate { get; set; }
        public int Weight { get; set; }
    }
}
