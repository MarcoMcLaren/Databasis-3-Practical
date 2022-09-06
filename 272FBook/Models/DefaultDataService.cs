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
        private SqlConnection currConnection;

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
        public bool openConnection()
        {
            bool status = true;
            try
            {
                String conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                currConnection = new SqlConnection(conString);
                currConnection.Open();
            }
            catch
            {
                status = false;
            }
            return status;
        }

        public bool closeConnection()
        {
            if (currConnection != null)
            {
                currConnection.Close();
            }
            return true;

        }
        public List<Student> getAllStudentsByMarkRange(int min, int max)
        {
            List<Student> students = new List<Student>();
            //TODO: get all students whose grade falls between min and max (inclusive)

            try
            {
                openConnection();
                SqlCommand command = new SqlCommand("SELECT DISTINCT Students.ID,Students.FirstName, Students.LastName,Images.B64Image from Students INNER JOIN Images ON Students.ID = Images.StudentID WHERE Grade > '" + min + "' AND Grade < '" + max + "'", currConnection);
                using (SqlDataReader reader = command.ExecuteReader()) //lees van databasisse gebruik ExcecuteRader, NA databasis stuur ExcecuteNonQuery
                {
                    while (reader.Read())
                    {
                        Student tmpDest = new Student();
                        tmpDest.FirstName = reader["FirstName"].ToString();
                        tmpDest.Surname = reader["LastName"].ToString();
                        tmpDest.ID = Convert.ToInt32(reader["ID"]);
                        students.Add(tmpDest);
                    }
                }
                closeConnection();
            }
            catch
            {
            }

            return students;
        }


        public List<Student> getAllStudentsBySexAndMarkRange(String sex, int min, int max)
        {
            List<Student> students = new List<Student>();
            //TODO: get all students whose grade falls between min and max (inclusive) and whose recorded sex matches the method's first argument
            try
            {
                openConnection();
                SqlCommand command = new SqlCommand("SELECT DISTINCT Students.ID,Students.FirstName, Students.LastName,Images.B64Image from Students INNER JOIN Images ON Students.ID = Images.StudentID WHERE Grade > '" + min + "' AND Grade < '" + max + "'", currConnection);
                using (SqlDataReader reader = command.ExecuteReader()) //lees van databasisse gebruik ExcecuteRader, NA databasis stuur ExcecuteNonQuery
                {
                    while (reader.Read())
                    {
                        Student tmpDest = new Student();
                        tmpDest.FirstName = reader["FirstName"].ToString();
                        tmpDest.Surname = reader["LastName"].ToString();
                        tmpDest.ID = Convert.ToInt32(reader["ID"]);
                        students.Add(tmpDest);
                    }
                }
                closeConnection();
            }
            catch
            {
            }

            return students;
        }

        public List<Image> getAllImages() {
            List<Image> images = new List<Image>();
            //TODO: Retrieve all the information associated with the images
            try
            {
                openConnection();
                SqlCommand command = new SqlCommand("SELECT * from Images", currConnection);
                using (SqlDataReader reader = command.ExecuteReader()) //lees van databasisse gebruik ExcecuteRader, NA databasis stuur ExcecuteNonQuery
                {
                    while (reader.Read())
                    {
                        Image tmpDest = new Image();
                        tmpDest.ImageRaw = "B64Image";
                        tmpDest.StudentID = Convert.ToInt32(reader["StudentID"]);
                        images.Add(tmpDest);
                    }
                }
                closeConnection();
            }
            catch
            {
            }

            return images;
        }
    }
}