using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student.Context;
using Student.Models;

namespace Student.Controllers
{
    public class InstructorController : Controller
    {
        SchoolContext db = new SchoolContext();
        // GET: Instructor
        public ActionResult Index(int? id, int? courseId)
        {
            var viewModel = new InstructorIndexData();
            viewModel.Instructors = db.Instructors
                .Include(i => i.OfficeAssignment)
                .Include(i => i.Courses.Select(c => c.Department))
                .OrderBy(i => i.LastName);

            if (id != null)
            {
                ViewBag.InstructorID = id.Value;
                viewModel.Courses = viewModel.Instructors.Single(i => i.ID == id.Value).Courses;
            }

            if (courseId != null)
            {
                ViewBag.CourseID = courseId.Value;
                //viewModel.Enrollments = viewModel.Courses.Single(i => i.CourseID == courseId).Enrollments;

                //viewModel.Enrollments = viewModel.Courses.Where(
                //    x => x.CourseID == courseId).Single().Enrollments;

                var selectedCourse = viewModel.Courses.Where(x => x.CourseID == courseId).Single();
                db.Entry(selectedCourse).Collection(x => x.Enrollments).Load();
                foreach (Enrollment enrollment in selectedCourse.Enrollments)
                {
                    db.Entry(enrollment).Reference(x => x.Student).Load();
                }

                viewModel.Enrollments = selectedCourse.Enrollments;
            }
            return View(viewModel);
        }
    }
}