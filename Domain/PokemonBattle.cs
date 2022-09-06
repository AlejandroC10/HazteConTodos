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
    
    public void DeleteBattle()
    {
    }
    
    public void Combat()
    {
        var pokemonOne = SelectedPokemon[0];
        var pokemonTwo = SelectedPokemon[1];

        Attack(pokemonOne,pokemonTwo);
        CheckWinnner(pokemonOne, pokemonTwo);
        
        if (CombatWinner is null)
        {
            Attack(pokemonTwo,pokemonOne);
            CheckWinnner(pokemonTwo, pokemonOne);
        }
        if (CombatWinner is null)
        {
            CombatStatus = $"{pokemonOne.Name["english"]}: {pokemonOne.Stats["HP"]} HP | {pokemonTwo.Name["english"]}: {pokemonTwo.Stats["HP"]} HP";
        }else
            CombatStatus = $"{CombatWinner} is the WINNER";
    }

    public void Attack(Pokemon attacker, Pokemon defender)
    {
        var attackerDamage = attacker.CalculateDamage(defender.Type);
        defender.TakeDamage(attackerDamage);
    }
    
    public void CheckWinnner(Pokemon attacker, Pokemon defender)
    {
        if (defender.Stats["HP"] <= 0)
        {
            CombatWinner = $"{attacker.Name["english"]}";
        }
    }
}