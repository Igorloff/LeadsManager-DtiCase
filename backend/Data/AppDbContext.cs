using LeadsManager.backend.Models;
using Microsoft.EntityFrameworkCore;

namespace LeadsManager.backend.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Lead> Leads { get; set; }
    }
}