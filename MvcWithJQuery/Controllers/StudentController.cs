using MvcWithJQuery.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWithJQuery.Controllers
{
    //[HandleError(ExceptionType = typeof(SqlException), View = "Error")]
    public class StudentController : Controller
    {
        // GET: Student
        [HttpGet]
        public ActionResult AllStudents()
        {
            List<Student> students = ContextDb.GetInstance().GetStudents();
            return View(students);
        }

        [HttpGet]
        public ActionResult InsertData()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertData(Student student)
        {
            ContextDb.GetInstance().InsertStudent(student);
            return RedirectToAction("AllStudents", "Student");
        }


        [HttpGet]
        public ActionResult Update(int Id)
        {
            Student std = ContextDb.GetInstance().GetSingleStudent(Id);
            return View(std);
        }
        [HttpPost]
        public ActionResult Update(Student student)
        {
            ContextDb.GetInstance().UpdateStudent(student);
            return RedirectToAction("AllStudents", "Student");
        }

        public ActionResult Delete(int Id)
        {
            ContextDb.GetInstance().DeleteStudent(Id);
            return RedirectToAction("AllStudents", "Student");
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            if (filterContext.ExceptionHandled)
                return;

            // Redirect on error:
            //filterContext.Result = RedirectToAction("Index", "Error");

            // OR set the result without redirection:
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/CustomErrors.cshtml"
            };
        }
    }
}