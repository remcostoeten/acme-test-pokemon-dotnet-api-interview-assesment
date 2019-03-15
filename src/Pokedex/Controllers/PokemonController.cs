using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Pokedex.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class PokemonController : ControllerBase
  {
    private static List<Pokemon> caughtPokemon = new List<Pokemon>();

    // GET api/pokemon
    [HttpGet]
    public async Task<ActionResult<string>> Get()
    {
      return await System.IO.File.ReadAllTextAsync("./Resources/all-pokemon.json");
    }

    // GET api/pokemon/5
    [HttpGet("{id}")]
    public async Task<ActionResult<string>> Get(int id)
    {
      using (var client = new HttpClient())
      {
        var response = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
        return await response.Content.ReadAsStringAsync();
      }
    }

    // POST api/pokemon
    [HttpPost("{id}/pokedex")]
    public async Task<ActionResult<string>> AddPokemonToPokedex(int id)
    {
      if (id > 151)
      {
        return BadRequest("We don't want new pokemons.");
      }
      try
      {
        var pokemonJson = await Get(id);

        JObject jObject = JObject.Parse(pokemonJson.Value);
        JToken jUser = jObject["name"];
        var name = (string)jUser;

        Pokemon pokemon = new Pokemon(id);
        pokemon.Name = name;

        if (!caughtPokemon.Exists((obj) => obj.Name.Equals(pokemon.Name)))
        {
          caughtPokemon.Add(pokemon);
          return Ok(caughtPokemon);
        }
        else
        {
          return BadRequest("Pokemon already caught.");
        }
      }
      catch (Exception e)
      {
        return NotFound();
      }
    }

    [HttpGet("pokedex")]
    public ActionResult<string> GetPokemonInPokedex()
    {
      return Ok(caughtPokemon);
    }

    // DELETE api/pokemon/5
    [HttpDelete("{id}/pokedex")]
    public ActionResult<string> Delete(int id)
    {
      Pokemon pokemon = caughtPokemon.Find((obj) => obj.Id.Equals(id));
      if (pokemon != null)
      {
        caughtPokemon.Remove(pokemon);
        return Ok(caughtPokemon);
      }
      return NotFound();
    }
  }
}
