using Microsoft.EntityFrameworkCore;

namespace ExampleApi.Models
{
    public class WorkersContext : DbContext
    {
        public WorkersContext()
        {
        }

        public WorkersContext(DbContextOptions<WorkersContext> options) : base(options)
        {
        }
        public virtual DbSet<Workers> Workers { get; set; }
        }
    }