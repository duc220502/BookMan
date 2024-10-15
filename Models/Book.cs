using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleAppp.Models
{
    internal class Book
    {
        private int _id { get; set; } = 1;
        public int Id
        {
            get { return _id; }

            set { if (value >= 1) _id = value; }
        }

        private string _authors { get; set; } = "Unknow author";

        public string Authors
        {
            get { return _authors; }

            set { if (!string.IsNullOrEmpty(value)) _authors = value; }

        }

        private string _title { get; set; } = "A new book";

        public string Title
        {
            get { return _title; }
            set { if (!string.IsNullOrEmpty(value)) _title = value; }
        }

        private string _publisher { get; set; } = "Unknow publisher";
        public string Publisher
        {
            get { return _publisher; }
            set { if (!string.IsNullOrEmpty(value)) _publisher = value; }
        }

        private int _year { get; set; } = 2018;
        public int Year
        {
            get { return _year; }
            set { if (value >= 1990) _year = value; }
        }

        private int _edition { get; set; } = 1;
        public int Edition
        {
            get { return _edition; }
            set { if (value >= 1) _edition = value; }
        }

        public string Isbn { get; set; } = "";
        public string Tags { get; set; } = "";
        public string Description { get; set; } = "A new book";
        public int _rating { get; set; } = 1;

        public int Rating
        {
            get { return _rating; }
            set { if (value >= 1 && value <= 5) _rating = value; }
        }

        public bool Reading { get; set; }

        private string _file { get; set; }
        public string File
        {
            get { return _file; }
            set { if (System.IO.File.Exists(value)) _file = value; }
        }

        public string FileName
        {
            get { return System.IO.Path.GetFileName(_file); }
        }
    }
}
