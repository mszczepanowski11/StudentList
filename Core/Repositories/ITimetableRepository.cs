using System;
using StudentList.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentList.Core.Repositories
{
	public interface ITimetableRepository
	{
		IQueryable<Timetable> Timetables { get; }
		IQueryable<Student> GetStudents();
		IList<Timetable> GetTimetables(int id);
        Task<List<Timetable>> GetCurrentTimetables();

        Timetable Find(int? id);
		Timetable Add(Timetable timetable);
		Timetable Update(Timetable timetable);
		Timetable Delete(int? id);
	}
}

