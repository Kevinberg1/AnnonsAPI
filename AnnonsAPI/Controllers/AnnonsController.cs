using AnnonsAPI.Data;
using AnnonsAPI.Modell;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnnonsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnonsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public AnnonsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }




        private static List<Annons> annons = new List<Annons>
        {
            new Annons
            {
                Id = 1, ProductName = "Celsius", 
                ProductType = "Drink",
                Price= 23, 
                CreatedDateTime = DateTime.Now
            },
            new Annons
            {
                Id = 2, ProductName = "ASUS ROG STRIX", 
                ProductType = "Super Computer",
                Price= 23000, 
                CreatedDateTime = DateTime.Now
            },
        };

        [HttpGet]
        public async Task<ActionResult<List<Annons>>> GetAll()
        {
            return Ok(annons);
        }

        [HttpGet]
        [Route("{id}")]
       
        public async Task<ActionResult<Annons>> GetOne(int id)
        {
            var advertisements = _dbContext.Advertisements.Find(id);

            if (advertisements == null)
            {
                return BadRequest("Advertisement not found");
            }
            return Ok(advertisements);
        }

        [HttpPost]
        public async Task<ActionResult<Annons>> PostAdvertisement(Annons annonser)
        {
            _dbContext.Advertisements.Add(annonser);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Advertisements.ToListAsync());

        }
        [HttpPut]
        public async Task<ActionResult<Annons>> UpdateAdvertisement(Annons annonser)
        {

            var annonsToUpdate = await _dbContext.Advertisements.FindAsync(annonser.Id);

            if (annonsToUpdate == null)
            {
                return BadRequest("Advertisement not found");
            }

            annonsToUpdate.ProductName = annonser.ProductName;
            annonsToUpdate.ProductType = annonser.ProductType;
            annonsToUpdate.Price = annonser.Price;
            annonsToUpdate.CreatedDateTime = DateTime.Now;

            await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.Advertisements.ToListAsync());

        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Annons>> Delete(int id)
        {
            var anonnser = await _dbContext.Advertisements.FindAsync(id);

            if (anonnser == null)
            {
                return BadRequest("Advertisement not found");
            }

            _dbContext.Advertisements.Remove(anonnser);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Advertisements.ToListAsync());

        }

    }

}
