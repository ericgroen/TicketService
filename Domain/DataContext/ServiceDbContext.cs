using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.DataContext
{
    public class ServiceDbContext : DbContext
    {
        public ServiceDbContext(DbContextOptions<ServiceDbContext> opt) : base(opt) { }

        public DbSet<Ticket> Ticket { get; set; }
    }
}
