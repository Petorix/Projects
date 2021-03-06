﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MyFitnessApp.Models
{
    public class ExternalContent
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string HTML { get; set; }
    }
}
