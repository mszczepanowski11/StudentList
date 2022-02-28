using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentList.Core.Repositories;
using StudentList.Data;
using StudentList.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentList.Controllers
{
    public class ClassroomsController : Controller
    {
        private IClassroomRepository classroomRepository;

        public ClassroomsController(IClassroomRepository classroomRepository)
        {
            this.classroomRepository = classroomRepository;
        }

        public IActionResult Index()
        {
            return View(classroomRepository.Classrooms);
        }


        public IActionResult Add()
        {
            return View("ClassroomForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Classroom classroom)
        {

            classroomRepository.Add(classroom);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            var editForm = classroomRepository.Classrooms.Where(m => m.Id == id).FirstOrDefault();

            return View("EditForm", editForm);
        }

        [HttpPost]
        public IActionResult Update(Classroom classroom)
        {
            classroomRepository.Update(classroom);
            return RedirectToAction("Index");

        }
        public IActionResult DeletePost(int? id)
        {
            classroomRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}