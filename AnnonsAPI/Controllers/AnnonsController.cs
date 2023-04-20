using AnnonsAPI.Modell;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnnonsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnonsController : ControllerBase
    {
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
            var annonser = annons.Find(a => a.Id == id);

            if (annonser == null)
            {
                return BadRequest("Annons not found");
            }
            return Ok(annonser);
        }

        [HttpPost]
        public async Task<ActionResult<Annons>> PostHero(Annons annonser)
        {
            annons.Add(annonser);
            return Ok(annons);
        }
        [HttpPut]
        public async Task<ActionResult<Annons>> UpdateHero(Annons annonser)
        {
           
            var annonsToUpdate = annons.Find(s => s.Id == annonser.Id);

            if (annonsToUpdate == null)
            {
                return BadRequest("Superhero not found");
            }

            annonsToUpdate.ProductName = annonser.ProductName;
            annonsToUpdate.ProductType = annonser.ProductType;
            annonsToUpdate.Price = annonser.Price;
            annonsToUpdate.CreatedDateTime = DateTime.Now;

            return Ok(annons);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Annons>> Delete(int id)
        {
            var anonnser = annons.Find(a => a.Id == id);

            if (anonnser == null)
            {
                return BadRequest("Annons not found");
            }

            annons.Remove(anonnser);
            return Ok(annons);
        }

    }

}
