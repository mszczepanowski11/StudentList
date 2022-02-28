using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentList.Core.Models
{

	public class Timetable
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public DateTime Time { get; set; }
		[Required]
		public Group Group { get; set; }
		
		public ICollection<Classroom> Classrooms { get; set;}
		public ICollection<Student> Students { get; set; }
		
		public Timetable()
		{
			Classrooms = new Collection<Classroom>();
			Students = new Collection<Student>();
		}
	}
}

