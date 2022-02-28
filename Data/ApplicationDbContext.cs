using System;
using StudentList.Core.Models;
using Microsoft.EntityFrameworkCore;


namespace StudentList.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
        public DbSet<Group> Groups { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Timetable>().Navigation(p => p.Group).AutoInclude();
            modelBuilder.Entity<Timetable>().Navigation(d => d.Students).AutoInclude();
            modelBuilder.Entity<Timetable>().Navigation(m => m.Classrooms).AutoInclude();
        }
    }
}

