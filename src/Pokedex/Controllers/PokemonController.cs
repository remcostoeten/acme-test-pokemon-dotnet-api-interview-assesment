using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private static List<string> caughtPokemon = new List<string>();

        // GET api/pokemon
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            return await System.IO.File.ReadAllTextAsync("./Resources/all-pokemon.json");
        }

        // GET api/pokemon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(string id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
                return await response.Content.ReadAsStringAsync();
            }
        }

        // POST api/pokemon
        [HttpPost("pokedex")]
        public void AddPokemonToPokedex([FromBody] string value)
        {
            caughtPokemon.Add(value);
        }

        [HttpGet("pokedex")]
        public ActionResult<string> GetPokemonInPokedex()
        {
            return Ok(caughtPokemon);
        }

        // DELETE api/pokemon/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
