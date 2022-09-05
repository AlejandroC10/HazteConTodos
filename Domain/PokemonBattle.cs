using System.Text.Json;

namespace Domain;

public class PokemonBattle
{
    public List<Pokemon> SelectedPokemon { get; set; }
    public string? CombatWinner { get; set; }
    public string CombatStatus { get; set; }

    public PokemonBattle()
    {
        CombatStatus = "";
    }

    public void CreateBattle(Pokemon pokemonOne, Pokemon pokemonTwo)
    {
        SelectedPokemon = new List<Pokemon> { pokemonOne, pokemonTwo };
    }
    
    public void SaveBattle()
    {
        var pokemonOne = SelectedPokemon[0].Id;
        var pokemonTwo = SelectedPokemon[1].Id;
        
        var jsonContent = JsonSerializer.Serialize<PokemonBattle>(this);
        var path = AppDomain.CurrentDomain.BaseDirectory;
        File.WriteAllText(Path.Combine(path, $"{pokemonOne}vs{pokemonTwo}.json"), jsonContent);
    }
    
    public void Combat()
    {
        var pokemonOne = SelectedPokemon[0];
        var pokemonTwo = SelectedPokemon[1];

        Attack(pokemonOne,pokemonTwo);
        
        Attack(pokemonTwo,pokemonOne);
    }

    public void Attack(Pokemon attacker, Pokemon defender)
    {
        var attackerDamage = attacker.CalculateDamage(defender.Type);
        defender.TakeDamage(attackerDamage);
    }
}