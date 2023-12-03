using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
