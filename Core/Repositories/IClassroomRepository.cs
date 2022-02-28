using System;
using StudentList.Core.Models;

namespace StudentList.Core.Repositories
{
	public interface IClassroomRepository {

		IQueryable<Classroom> GetClassrooms();
		IQueryable<Classroom> Classrooms { get; }

		Classroom Find(int? id);
		Classroom Delete(int? id);
		Classroom Add(Classroom classroom);
		Classroom Update(Classroom classroom);

	}
}

