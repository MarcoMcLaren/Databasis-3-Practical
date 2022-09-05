using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RandomCourseFBook.Models
{
    public class StudentRecordsVM
    {
        private Random rndGen = new Random();
        public List<Student> Students { get; set; }
        public List<Image> Images { get; set; }

        public String GetImageOf(int StudentId) {
            List<Image> results = Images.Where(img => img.StudentID == StudentId).ToList();
            return results[rndGen.Next(results.Count)].ImageRaw;
        }
    }
}