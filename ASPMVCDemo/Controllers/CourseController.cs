using ASPMVCDemo.Models;
using ASPMVCDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPMVCDemo.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService courseService;

        public CourseController(CourseService courseService)
        {
            this.courseService = courseService;
        }

        public IActionResult Index()
        {
            IEnumerable<CourseModel> courses = courseService.GetCourses();
            return View(courses);
        }
    }
}