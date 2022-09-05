using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RandomCourseFBook.Models
{
    public class Student
    {
        public int ID { get; set; }
        public String FirstName { get; set; }
        public String Surname { get; set; }
        public String Sex { get; set; }
        public int Grade { get; set; }
    }
}