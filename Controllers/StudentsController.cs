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
    public class StudentsController : Controller
    {
        private IStudentRepository repository;

        public StudentsController(IStudentRepository repository)
        {
            this.repository = repository;
        }

       
        public IActionResult Index()
        { 
            return View(repository.Students);
        }


        public IActionResult Add()
        {
            return View("StudentForm");
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            //if (ModelState.IsValid)
            //{
                repository.Add(student);
                return RedirectToAction("Index");
            //}

            //return View("StudentForm");
        }

        public IActionResult Edit(int? id)
        {
            var editForm = repository.Students.Where(d => d.Id == id).FirstOrDefault();

            return View("EditForm", editForm);
        }

        [HttpPost]
        public IActionResult Update(Student student)
        {
            repository.Update(student);
            return RedirectToAction("Index");

        }
        public IActionResult DeletePost(int? id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}