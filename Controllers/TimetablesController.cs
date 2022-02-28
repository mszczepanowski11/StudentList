using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentList.Core.Repositories;
using StudentList.Data;
using StudentList.Core.Models;
using StudentList.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentList.Controllers
{
    public class TimetablesController : Controller
    {
        private ITimetableRepository timetableRepository;
        private IStudentRepository studentRepository;
        private IGroupRepository groupRepository;
        private IClassroomRepository classroomRepository;

        public TimetablesController(ITimetableRepository timetableRepository,IStudentRepository studentRepository, IGroupRepository groupRepository, IClassroomRepository classroomRepository)
        {
            this.timetableRepository = timetableRepository;
            this.studentRepository = studentRepository;
            this.groupRepository = groupRepository;
            this.classroomRepository = classroomRepository;

        }

        [Route("Timetables/Index/{id}")]
        public IActionResult Index(int id)
        {
        
            IList<Timetable> TimetableList = timetableRepository.GetTimetables(id);
            ViewBag.GroupId = id;

            var TimetableView = new TimetableDetailView
            {
                Timetables = TimetableList
            };

            return View(TimetableView);

        }

        [Route("Timetables/Add/{id}")]
        public IActionResult Add(int id)
        {
            var students   = (from d in studentRepository.Students select d).ToList();
            var classrooms = (from m in classroomRepository.Classrooms select m).ToList();

            ViewBag.StudentList = students;
            ViewBag.ClassroomList = classrooms;
            ViewBag.GroupId = id;
           
            return View("TimetableForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Timetable timetable)
        {
            string[] classroomsIds = HttpContext.Request.Form["ClassroomId"].ToArray();
            string[] studentsIds = HttpContext.Request.Form["StudentId"].ToArray();
         
            List<Classroom> classrooms = new List<Classroom>();
            List<Student> students = new List<Student>();

            for (int i=0; i < classroomsIds.Length; i++)
            {
                Classroom classroom = classroomRepository.Find(Convert.ToInt32(classroomsIds[i]));
                classrooms.Add(classroom);
            }

            for(int i=0; i < studentsIds.Length; i++)
            {
                Student student = studentRepository.Find(Convert.ToInt32(studentsIds[i]));
                students.Add(student);
            }

            timetable.Students = students;
            timetable.Classrooms = classrooms;
         
            int GroupId = Convert.ToInt32(HttpContext.Request.Form["GroupId"].ToString());   
            
            timetable.Group = groupRepository.Groups.Where(p => p.Id == GroupId).FirstOrDefault();

            timetableRepository.Add(timetable);

            return RedirectToAction("Index",new {id = GroupId});
        }

        public IActionResult DeletePost(int? id)
        {
            timetableRepository.Delete(id);
            return RedirectToAction("Index", new {id = id});
        }
    }
}    