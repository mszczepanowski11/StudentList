using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StudentList.Core.Models
{
	public class Student
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string IdentityNumber { get; set; }

		public ICollection<Timetable> Timetables { get; set; }

		public Student()
		{
			
		}
	}
}
