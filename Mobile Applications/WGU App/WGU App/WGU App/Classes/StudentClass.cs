using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace WGU_App.Classes
{
    class StudentClass
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int ForeignTermId { get; set; }
        
        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Status { get; set; }

        public string Instructor { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public bool Notifications { get; set; }

        public string Notes { get; set; }

        public int UniqueHash { get; set; }
    }
}
