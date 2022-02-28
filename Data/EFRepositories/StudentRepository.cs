using System;
using System.Data.Entity;
using System.Collections.Generic;
using StudentList.Core.Repositories;
using StudentList.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace StudentList.Data.EFRepositories
{
	public class StudentRepository:IStudentRepository
	{
		private readonly ApplicationDbContext _context;
        public IQueryable<Student> Students => _context.Students;

        public StudentRepository(ApplicationDbContext context)
		{
			_context = context;

		}

        public Student Find(int? id)
        {
            return _context.Students.Find(id);
        }

       public Student Delete(int? id)
        {
            var entity = _context.Students.Remove(Find(id)).Entity;
            _context.SaveChanges();

            return entity;
        }

        public Student Add(Student student)
        {
            var entity = _context.Students.Add(student).Entity;
            _context.SaveChanges();

            return entity;
        }

        public Student Update(Student student)
        {
            var entity = _context.Students.Where(d => d.Id == student.Id).FirstOrDefault();

            _context.Students.Remove(entity);
            _context.Students.Add(student);
            _context.SaveChanges();

            return entity;
        }
    }
}

