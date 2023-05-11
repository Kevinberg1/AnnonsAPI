using AnnonsAPI.Modell;
using Microsoft.EntityFrameworkCore;

namespace AnnonsAPI.Data
{
    
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions options) : base(options)
            {
            }

            public DbSet<Annons> Advertisements { get; set; }
        }

    
}
