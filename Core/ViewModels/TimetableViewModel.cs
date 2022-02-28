using System;
using StudentList.Core.Models;
namespace StudentList.Core.ViewModels
{
	public class TimetableDetailView
	{
		public IEnumerable<Timetable> Timetables { get; set; }

		public TimetableDetailView()
        {
			Timetables = new List<Timetable>();
        }
	}
}

