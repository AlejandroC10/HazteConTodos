using Application;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace PokemonApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonController : ControllerBase
{
    private IPokemonDb pokemonDataBase;

    public PokemonController(IPokemonDb pokemonDb)
    {
        pokemonDataBase = pokemonDb;
    }

    [HttpGet]
    public List<Pokemon> Get()
    {
        var pokedex = new Pokedex(pokemonDataBase);
        return pokedex.FindAllPokemon();
    }
    
    [HttpGet]
    [Route("{id}")]
    public Pokemon Get(int id)
    {
        var pokedex = new Pokedex(pokemonDataBase);
        return pokedex.FindPokemonById(id);
    }
    
    [HttpGet]
    [Route("Type/{type}")]
    public List<Pokemon> Get(string type)
    {
        var pokedex = new Pokedex(pokemonDataBase);
        return pokedex.FindPokemonByType(type);
    }
    
    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete(int id)
    {
        var pokedex = new Pokedex(pokemonDataBase);
        pokedex.DeletePokemonById(id);
        
        return Ok();
    }
    
    [HttpPut]
    [Route("{id}")]
    public IActionResult Put(int id, string key, int change)
    {
        var pokedex = new Pokedex(pokemonDataBase);
        pokedex.ModifyPokemonById(id, key, change);
        
        return Ok();
    }
    
    [HttpGet]
    [Route("combat")]
    public IActionResult Get(int pkOne, int pkTwo)
    {
        var pokedex = new Pokedex(pokemonDataBase);

        var pokemonOne = pokedex.FindPokemonById(pkOne);
        var pokemonTwo = pokedex.FindPokemonById(pkTwo);

        var pokemonBattle = new PokemonBattle();
        pokemonBattle.CreateBattle(pokemonOne, pokemonTwo);
        pokemonBattle.Combat();

        if (pokemonBattle.CombatWinner != null)
        {
            pokemonBattle.DeleteBattle();    
        }
        else
        {
            pokemonBattle.SaveBattle();
        }
        
        return Ok(pokemonBattle.CombatStatus);
    }
}