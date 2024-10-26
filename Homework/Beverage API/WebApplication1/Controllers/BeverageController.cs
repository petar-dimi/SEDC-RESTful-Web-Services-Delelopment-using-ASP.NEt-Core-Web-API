using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeverageController : ControllerBase
    {
        // GET: api/beverage
        [HttpGet]
        public ActionResult<IEnumerable<Beverage>> GetBeverages()
        {
            return Ok(StaticDb.Beverages);
        }

        // GET: api/beverage/{id}
        [HttpGet("{id}")]
        public ActionResult<Beverage> GetBeverageById(int id)
        {
            var beverage = StaticDb.Beverages.FirstOrDefault(b => b.Id == id);
            if (beverage == null) return NotFound();
            return Ok(beverage);
        }

        // GET: api/beverage/filter?type=Alcohol
        [HttpGet("filter")]
        public ActionResult<IEnumerable<Beverage>> GetBeveragesByType(string type)
        {
            var beverages = StaticDb.Beverages.Where(b => b.Type.Equals(type, System.StringComparison.OrdinalIgnoreCase)).ToList();
            if (!beverages.Any()) return NotFound();
            return Ok(beverages);
        }

        // Admin: POST: api/beverage
        [HttpPost]
        public ActionResult<Beverage> AddBeverage([FromBody] Beverage beverage)
        {
            beverage.Id = StaticDb.Beverages.Max(b => b.Id) + 1; // Assign a new ID
            StaticDb.Beverages.Add(beverage);
            return CreatedAtAction(nameof(GetBeverages), beverage);
        }

        // Admin: PUT: api/beverage/{id}
        [HttpPut("{id}")]
        public ActionResult<Beverage> UpdateBeverage(int id, [FromBody] Beverage beverage)
        {
            var existingBeverage = StaticDb.Beverages.FirstOrDefault(b => b.Id == id);
            if (existingBeverage == null) return NotFound();

            existingBeverage.Name = beverage.Name;
            existingBeverage.Type = beverage.Type;
            existingBeverage.QuantityInStock = beverage.QuantityInStock;
            existingBeverage.Price = beverage.Price;

            return NoContent();
        }

        // Admin: DELETE: api/beverage/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteBeverage(int id)
        {
            var beverage = StaticDb.Beverages.FirstOrDefault(b => b.Id == id);
            if (beverage == null) return NotFound();

            StaticDb.Beverages.Remove(beverage);
            return NoContent();
        }
    }
}
