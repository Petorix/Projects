using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace WGU_App.Classes
{
    class Term
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Term()
        {
            Name = "New Term";
            StartDate = DateTime.Today;
            EndDate = DateTime.Today.AddDays(1);
        }
    }
}
