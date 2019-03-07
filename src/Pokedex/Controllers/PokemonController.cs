using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        // GET api/pokemon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var result = await GetPokemon();
            return new string[] { "value1", "value2" };
        }

        private async Task<string> GetPokemon()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://pokeapi.co/api/v2/pokemon/ditto");
                return await response.Content.ReadAsStringAsync();
            }
        }

        // GET api/pokemon/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/pokemon
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/pokemon/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/pokemon/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
