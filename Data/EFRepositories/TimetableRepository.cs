using System;
using System.Data.Entity;
using System.Collections.Generic;
using StudentList.Core.Repositories;
using StudentList.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentList.Data.EFRepositories
{
	public class TimetableRepository : ITimetableRepository
	{
		private readonly ApplicationDbContext _context;
		public IQueryable<Timetable> Timetables => _context.Timetables;


		public TimetableRepository(ApplicationDbContext context)
		{
			_context = context;
		}

        public async Task<List<Timetable>> GetCurrentTimetables()
        {
            return await _context.Timetables.Include(p => p.Group).AsNoTracking().ToListAsync();
        }

        public IList<Timetable> GetTimetables(int GroupId)
		{
			return (from p in _context.Timetables where p.Group.Id.Equals(GroupId) select p).ToList();

		}

		public IQueryable<Student> GetStudents() 
		{
			return _context.Students.ToList().AsQueryable();
		}

		public Timetable Find(int? id)
		{
			return _context.Timetables.Find(id);
		}

		public Timetable Add(Timetable timetable)
        {
			var entity = _context.Timetables.Add(timetable).Entity;
			_context.SaveChanges(); 

			return entity;
        }

		public Timetable Update(Timetable timetable)
        {
			var entity = _context.Timetables.Where(p => p.Id == timetable.Id).FirstOrDefault();


			_context.Timetables.Remove(entity);
			_context.Timetables.Add(timetable);
			_context.SaveChanges();

			return entity;

        }

		public Timetable Delete(int? id)
        {
			var entity = _context.Timetables.Remove(Find(id)).Entity;
			_context.SaveChanges();
			
			return entity;
        }

    }
}

  