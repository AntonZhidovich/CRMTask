using Microsoft.EntityFrameworkCore;
using CRMTask.Models;

namespace CRMTask.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; } = null!;

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
