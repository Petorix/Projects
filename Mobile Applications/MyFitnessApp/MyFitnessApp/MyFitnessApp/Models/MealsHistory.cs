using SQLite;
using System;

namespace MyFitnessApp.Models
{
    public class MealsHistory
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public DateTime EntryDate { get; set; }
        public int MealsFK { get; set; }
    }
}
