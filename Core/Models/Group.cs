using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StudentList.Core.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ClassType { get; set; }

        [Required]
        public string ClassNumber { get; set; }


        public ICollection<Timetable> Timetables;
        public ICollection<Classroom> Classrooms;

        public Group()
        {
            Timetables = new Collection<Timetable>();
            Classrooms = new Collection<Classroom>();
        }
    }
}

