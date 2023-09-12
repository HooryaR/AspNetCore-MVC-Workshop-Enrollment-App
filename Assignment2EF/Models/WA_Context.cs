using Microsoft.EntityFrameworkCore;

namespace Assignment2EF.Models
{
    public class WA_Context : DbContext
    {
        public WA_Context (DbContextOptions<WA_Context> contextOptions)
            : base(contextOptions) { }

        //entity
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<Enrollement> Enrollements { get; set; }
    }
}
