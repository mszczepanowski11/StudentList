using System;
using System.Data.Entity;
using System.Collections.Generic;
using StudentList.Core.Repositories;
using StudentList.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace StudentList.Data.EFRepositories
{
	public class ClassroomRepository:IClassroomRepository
	{
		private readonly ApplicationDbContext _context;
        public IQueryable<Classroom> Classrooms => _context.Classrooms;

        public ClassroomRepository(ApplicationDbContext context)
		{
			_context = context;
		}

        public IQueryable<Classroom> GetClassrooms()
        {
            throw new NotImplementedException();
        }

        public Classroom Find(int? id)
        {
            return _context.Classrooms.Find(id);
        }

        public Classroom Delete(int? id)
        {
            var entity = _context.Classrooms.Remove(Find(id)).Entity;
            _context.SaveChanges();

            return entity;
        }

        public Classroom Add(Classroom classroom)
        {
            var entity = _context.Classrooms.Add(classroom).Entity;
            _context.SaveChanges();

            return entity;
        }

        public Classroom Update(Classroom classroom)
        {
            var entity = _context.Classrooms.Where(d => d.Id == classroom.Id).FirstOrDefault();

            _context.Classrooms.Remove(entity);
            _context.Classrooms.Add(classroom);
            _context.SaveChanges();

            return entity;
        }
    }
}

