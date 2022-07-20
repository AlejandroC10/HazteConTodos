using Application;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace PokemonApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonController : ControllerBase
{
    
    [HttpGet]
    public List<Pokemon> Get()
    {
        var db = new PokemonDb();
        var pokedex = new Pokedex(db);
        return pokedex.GetAll();
    }
    
    [HttpGet]
    [Route("{id}")]
    public Pokemon Get(int id)
    {
        var db = new PokemonDb();
        var pokedex = new Pokedex(db);
        return pokedex.FindPokemonById(id);
    }
    
    [HttpGet]
    [Route("Type/{type}")]
    public List<Pokemon> Get(string type)
    {
        var db = new PokemonDb();
        var pokedex = new Pokedex(db);
        return pokedex.FindByType(type);
    }
    
}