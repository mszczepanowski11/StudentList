using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentList.Core.Repositories;
using StudentList.Data;
using StudentList.Core.Models;
using Microsoft.AspNetCore.Authorization;

namespace StudentList.Controllers
{
    public class GroupsController : Controller
    {
        private IGroupRepository repository;

        public GroupsController(IGroupRepository repository)
        {
            this.repository = repository;
        }

        [Authorize]
        public IActionResult Index()
        {  
            return View(repository.Groups);
        }

        //GET - Create
        public IActionResult Add()
        {
            return View("GroupForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Group group)
        {
            if (ModelState.IsValid)
            { 
                repository.Add(group);
                return RedirectToAction("Index");

            }

            return View("GroupForm");
        }


        public IActionResult Edit(int? id)
        {
            var editForm = repository.Groups.Where(p => p.Id == id).FirstOrDefault();

            return View("EditForm",editForm);
        }


        [HttpPost]
        public IActionResult Update(Group group)
        {
            repository.Update(group);
            return RedirectToAction("Index");
        }
       
        public IActionResult DeletePost(int? id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Manage(int id)
        {
            var group = repository.Groups.Where(p => p.Id == id).FirstOrDefault();
            return View(group);
        }
    }
} 