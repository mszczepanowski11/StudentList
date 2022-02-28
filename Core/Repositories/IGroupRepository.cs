using System;
using System.Linq;
using StudentList.Core.Models;
namespace StudentList.Core.Repositories
{
    public interface IGroupRepository
    {
        IQueryable<Group> Groups { get; }

        Group Find(int? id);
        Group Delete(int? id);
        Group Add(Group group);
        Group Update(Group group);
    }
}
