using System;
using System.ComponentModel.DataAnnotations;

namespace StudentList.Core.Models
{
	public class Classroom

	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public ClassroomForm Form { get; set; }

		public ICollection<Timetable> Timetables { get; set; }

		public enum ClassroomForm
        {
			Stacjonarne = 1,
			Zdalne = 2
        }
	}
}

