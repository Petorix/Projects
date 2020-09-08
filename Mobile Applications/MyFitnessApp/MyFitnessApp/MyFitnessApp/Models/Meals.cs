using SQLite;
using System;

namespace MyFitnessApp.Models
{
    public class Meals
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string MealName { get; set; }
        public int Calories { get; set; }
        public int Carbs { get; set; }
        public int Fat { get; set; }
        public int Protein { get; set; }
        public int MealType { get; set; }
        public int MH_FK { get; set; }
        public DateTime Entry { get; set; }
    }
}
