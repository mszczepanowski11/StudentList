using StudentList.Core.Models;


namespace StudentList.Core.Repositories
{
    public interface IStudentRepository
	{
		IQueryable<Student> Students { get; }
		
		Student Find(int? id);
		Student Delete(int? id);
		Student Add(Student student);
		Student Update(Student student);
	}	
}

