using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace RandomCourseFBook.Models
{
    public class DefaultDataService
    {
        private String ConnectionString;
        public static List<MarkRange> markRanges = null;

        public DefaultDataService() {
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            markRanges = new List<MarkRange>();
            markRanges.Add(new MarkRange { Symbol = "F", MinOfRange = 0, MaxOfRange = 59 });
            markRanges.Add(new MarkRange { Symbol = "D", MinOfRange = 60, MaxOfRange = 64 });
            markRanges.Add(new MarkRange { Symbol = "D+", MinOfRange = 65, MaxOfRange = 69 });
            markRanges.Add(new MarkRange { Symbol = "C", MinOfRange = 70, MaxOfRange = 74 });
            markRanges.Add(new MarkRange { Symbol = "C+", MinOfRange = 75, MaxOfRange = 79 });
            markRanges.Add(new MarkRange { Symbol = "B", MinOfRange = 80, MaxOfRange = 84 });
            markRanges.Add(new MarkRange { Symbol = "B+", MinOfRange = 85, MaxOfRange = 89 });
            markRanges.Add(new MarkRange { Symbol = "A", MinOfRange = 90, MaxOfRange = 94 });
            markRanges.Add(new MarkRange { Symbol = "A+", MinOfRange = 95, MaxOfRange = 100 });
        }

        public List<Student> getAllStudentsByMarkRange(int min, int max)
        {
            List<Student> students = new List<Student>();
            //TODO: get all students whose grade falls between min and max (inclusive)
            return students;
        }


        public List<Student> getAllStudentsBySexAndMarkRange(String sex, int min, int max)
        {
            List<Student> students = new List<Student>();
            //TODO: get all students whose grade falls between min and max (inclusive) and whose recorded sex matches the method's first argument
            return students;
        }

        public List<Image> getAllImages() {
            List<Image> images = new List<Image>();
            //TODO: Retrieve all the information associated with the images
            return images;
        }
    }
}