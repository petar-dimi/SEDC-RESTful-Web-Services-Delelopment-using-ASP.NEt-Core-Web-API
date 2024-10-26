using Homework_02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeverageController : ControllerBase
    {
      
        [HttpGet]
        public ActionResult<IEnumerable<Beverage>> GetBeverages()
        {
            return Ok(StaticDb.Beverages);
        }

        
        [HttpGet("{index}")]
        public ActionResult<Beverage> GetBeverageByIndex(int index)
        {
            if (index < 0 || index >= StaticDb.Beverages.Count)
            {
                return NotFound();
            }
            return Ok(StaticDb.Beverages[index]);
        }

       
        [HttpGet("filter")]
        public ActionResult<IEnumerable<Beverage>> GetBeveragesByBrandAndType(string brand, string type)
        {
            var filteredBeverages = StaticDb.Beverages
                .Where(b => b.Brand.Equals(brand, System.StringComparison.OrdinalIgnoreCase) &&
                            b.Type.Equals(type, System.StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!filteredBeverages.Any())
            {
                return NotFound();
            }
            return Ok(filteredBeverages);
        }

        
        [HttpPost]
        public ActionResult<Beverage> AddBeverage([FromBody] Beverage beverage)
        {
            StaticDb.Beverages.Add(beverage);
            return CreatedAtAction(nameof(GetBeverages), beverage);
        }

       
        [HttpPost("bulk")]
        public ActionResult<IEnumerable<Beverage>> AddBeverages([FromBody] List<Beverage> beverages)
        {
            if (beverages == null || !beverages.Any())
            {
                return BadRequest("Beverages list cannot be null or empty.");
            }

            StaticDb.Beverages.AddRange(beverages);
            return CreatedAtAction(nameof(GetBeverages), beverages);
        }
    }
}
