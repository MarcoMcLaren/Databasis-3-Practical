using System;
using System.Linq;
using System.Web.Mvc;
using RandomCourseFBook.Models;

namespace RandomCourseFBook.Controllers
{
    public class HomeController : Controller
    {

        //rudimentary filters -- Students: if you're using the filtering approach as a reference in future work, please dont 
        public static String genderFilter = "Reset";
        public static int minFilter = 0;
        public static int maxFilter = 100;


        private DefaultDataService dataService = new DefaultDataService();

        public ActionResult Index()
        {
            StudentRecordsVM studentRecords = null;
            if (HomeController.genderFilter != null && HomeController.genderFilter.EndsWith("ale"))
            {
                studentRecords = new StudentRecordsVM { 
                    Students = dataService.getAllStudentsBySexAndMarkRange(genderFilter, minFilter, maxFilter),
                    Images = dataService.getAllImages()
                };

            }
            else {
                studentRecords = new StudentRecordsVM
                {
                    Students = dataService.getAllStudentsByMarkRange(minFilter, maxFilter),
                    Images = dataService.getAllImages()
                };
            }
            
            
            return View(studentRecords);
        }

        public ActionResult SetGradeFilter(String gradeSymbol)
        {
            MarkRange range = DefaultDataService.markRanges.FirstOrDefault(r => r.Symbol == gradeSymbol);
            if (range != null)
            {
                HomeController.minFilter = range.MinOfRange;
                HomeController.maxFilter = range.MaxOfRange;
            }
            else {
                HomeController.minFilter = 0;
                HomeController.maxFilter = 100;
            }
            return RedirectToAction("Index");
        }

        public ActionResult SetGenderFilter(String gender)
        {
            HomeController.genderFilter = gender;
            return RedirectToAction("Index");
        }

    }
}