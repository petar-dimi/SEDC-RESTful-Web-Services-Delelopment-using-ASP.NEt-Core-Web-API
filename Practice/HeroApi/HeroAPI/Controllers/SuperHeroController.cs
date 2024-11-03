using HeroAPI.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllHeroes()
        {
            var heroes = new List<SuperHero> {
                new SuperHero
                {
                    Id = 1,
                    Name = "Spiderman",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York",
                }
            };
            return Ok(heroes);
        }
    }
}
