using AnnonsAPI.Modell;
using Microsoft.EntityFrameworkCore;

namespace AnnonsAPI.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void MigrateData()
        {
            _dbContext.Database.Migrate();
            SeedData();
            _dbContext.SaveChanges();
        }

        private void SeedData()
        {
            if (!_dbContext.Advertisements.Any(e => e.Id == 1))
            {
                _dbContext.Add(new Annons
                {
                    ProductName = "Monster",
                    ProductType = "Drink",
                    Price = 23,
                    CreatedDateTime = DateTime.Now
                });
            }
        }
    }
}
