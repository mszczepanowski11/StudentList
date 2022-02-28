using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StudentList.Areas.Identity.Data;

public class StudentListIndentityDbContext : IdentityDbContext<IdentityUser>
{
    public StudentListIndentityDbContext(DbContextOptions<StudentListIndentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
