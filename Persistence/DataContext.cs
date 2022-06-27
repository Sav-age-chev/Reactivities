using Domain;
using Microsoft.EntityFrameworkCore;

/* DataContext is used as a services */

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        // Represent the Activity table/objects
         public DbSet<Activity> Activities { get; set; }
    }
}