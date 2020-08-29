using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace WGU_App.Classes
{
    class Assessment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int ForeignClassId { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int AssessmentType { get; set; }

        public bool Reminders { get; set; }

        public int UniqueHash { get; set; }
    }
}
