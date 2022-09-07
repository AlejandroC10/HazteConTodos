using System.Text.Json;

namespace Domain;

public interface IPokemonBattle
{
    public List<Pokemon> SelectedPokemon { get; set; }
    public string? CombatWinner { get; set; }
    public string CombatStatus { get; set; }
    
    public void CreateBattle(Pokemon pokemonOne, Pokemon pokemonTwo)
    {
    }
    
    public void SaveBattle()
    {
    }
    
    public void DeleteBattle()
    {
    }
    
    public void Combat()
    {
    }

    public void Attack(Pokemon attacker, Pokemon defender)
    {
    }
    
    public void CheckWinnner(Pokemon attacker, Pokemon defender)
    {
    }
}