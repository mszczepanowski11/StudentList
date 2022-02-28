using System;
using System.Data.Entity;
using System.Collections.Generic;
using StudentList.Core.Repositories;
using StudentList.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace StudentList.Data.EFRepositories
{
    public class GroupRepository:IGroupRepository
    {
    
        private readonly ApplicationDbContext _context;
        public IQueryable<Group> Groups => _context.Groups;

        public GroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Group Find(int? id)
        {
            return _context.Groups.Find(id);
        }
        
        public Group Delete(int? id)
        {
            var entity = _context.Groups.Remove(Find(id)).Entity;
            _context.SaveChanges();

            return entity; 
        }

        public Group Add(Group group)
        {
            var entity = _context.Groups.Add(group).Entity;
            _context.SaveChanges();

            return entity;
        }


        public Group Update(Group group)
        {
            var entity = _context.Groups.Where(p => p.Id == group.Id).FirstOrDefault();

            _context.Groups.Remove(entity);
            _context.Groups.Add(group);
            _context.SaveChanges();

            return entity;
        }


        
    }
}