using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace PokemonApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonController : ControllerBase
{
    
    [HttpGet]
    [Route("{id}")]
    public Pokemon Get(int id)
    {
        var pokedex = new Pokedex();
        return pokedex.FindPokemonById(id);
    }
    
    [HttpGet]
    [Route("Type/{type}")]
    public List<Pokemon> Get(string type)
    {
        var pokedex = new Pokedex();
        return pokedex.FindByType(type);
    }
    
    [HttpGet]
    public List<Pokemon> Get()
    {
        var pokedex = new Pokedex();
        return pokedex.GetAll();
    }
}