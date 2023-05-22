using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleMVVM.Models
{
    class Course
    {
        public string Name { get; set; }
        public int Hours { get; set; }
        public string Author { get; set; }
        public int Amount { get; set; }

        public Course(string name, int hours, string author, int amount)
        {
            this.Name = name;
            this.Hours = hours;
            this.Author = author;
            this.Amount = amount;
        }
    }
}
