using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loan.Controllers
{
    public class LoanController : Controller
    {
        // GET: Loan
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
                public ActionResult Grades()
        {
            return View("Grades");
        }
        [HttpPost]
        public ActionResult Index(double balance, double IR, int year)
        {
            ViewBag.balance = balance;
            ViewBag.IR = IR;
            ViewBag.year = year;
            for (int i = 0; i < year; i++)
            {
                balance += balance * (IR / 100);
            }
            Double Total = balance;
            ViewBag.Total =Total;
            return View();
        }

        [HttpPost]
        public ActionResult Grades(FormCollection gradesForm)
        {
            double grade1 = Double.Parse(gradesForm["grade1"]);
            double grade2 = Double.Parse(gradesForm["grade2"]);
            double grade3 = Double.Parse(gradesForm["grade3"]);
            double avg = (grade1 + grade2 + grade3) / 3;
            String letter;
            if (avg <= 100 && avg >= 90)
            {
                letter = "A";
            }
            else if (avg <= 89 && avg >= 80)
            {
                letter = "B";
            }
            else if (avg <= 79 && avg >= 70)
            {
                letter = "C";
            }
            else if (avg <= 69 && avg >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "E";
            }

            ViewBag.grade = letter;
            return View("Grades");

        }
    }
}