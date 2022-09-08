using System.Text.Json;
using System.Text.Json.Serialization;

namespace Domain;

public class PokemonBattle: IPokemonBattle
{
    public PokemonBattleInfo PokemonBattleInfo { get; set; }
    public IPokemonAttacker PokemonAttacker { get; set; }
    
    public PokemonBattle(IPokemonAttacker pokemonAttacker)
    {
        PokemonBattleInfo = new PokemonBattleInfo();
        PokemonAttacker = pokemonAttacker;

    }

    public void CreateBattle(Pokemon pokemonOne, Pokemon pokemonTwo)
    {
        var path = AppDomain.CurrentDomain.BaseDirectory;
        var filePath = Path.Combine(path, $"{pokemonOne.Id}vs{pokemonTwo.Id}.json");
        
        if (File.Exists(filePath))
        {
            var jsonContent = File.ReadAllText(filePath);
            var foundBattle = JsonSerializer.Deserialize<PokemonBattleInfo>(jsonContent);
            PokemonBattleInfo.SelectedPokemon = foundBattle!.SelectedPokemon;
            PokemonBattleInfo.CombatStatus = foundBattle!.CombatStatus;
            PokemonBattleInfo.CombatWinner = foundBattle!.CombatWinner;
        }
        else
        {
            PokemonBattleInfo.SelectedPokemon = new List<Pokemon> { pokemonOne, pokemonTwo };   
        }
    }
    
    public void SaveBattle()
    {
        var pokemonOne = PokemonBattleInfo.SelectedPokemon[0].Id;
        var pokemonTwo = PokemonBattleInfo.SelectedPokemon[1].Id;
        
        var jsonContent = JsonSerializer.Serialize<PokemonBattleInfo>(PokemonBattleInfo);
        var path = AppDomain.CurrentDomain.BaseDirectory;
        File.WriteAllText(Path.Combine(path, $"{pokemonOne}vs{pokemonTwo}.json"), jsonContent);
    }
    
    public void DeleteBattle()
    {
        var pokemonOne = PokemonBattleInfo.SelectedPokemon[0].Id;
        var pokemonTwo = PokemonBattleInfo.SelectedPokemon[1].Id;
        
        var path = AppDomain.CurrentDomain.BaseDirectory;
        File.Delete(Path.Combine(path, $"{pokemonOne}vs{pokemonTwo}.json"));
    }
    
    public void Combat()
    {
        var pokemonOne = PokemonBattleInfo.SelectedPokemon[0];
        var pokemonTwo = PokemonBattleInfo.SelectedPokemon[1];

        Attack(pokemonOne,pokemonTwo);
        CheckWinnner(pokemonOne, pokemonTwo);
        
        if (PokemonBattleInfo.CombatWinner is null)
        {
            Attack(pokemonTwo,pokemonOne);
            CheckWinnner(pokemonTwo, pokemonOne);
        }
        
        if (PokemonBattleInfo.CombatWinner is null)
        {
            PokemonBattleInfo.CombatStatus = $"{pokemonOne.Name["english"]}: {pokemonOne.Stats["HP"]} HP | {pokemonTwo.Name["english"]}: {pokemonTwo.Stats["HP"]} HP";
        }
        else
        {
            PokemonBattleInfo.CombatStatus = $"{PokemonBattleInfo.CombatWinner} is the WINNER";
        }
    }

    public void Attack(Pokemon attacker, Pokemon defender)
    {
        var attackerDamage = attacker.CalculateDamage(defender.Type, PokemonAttacker.CalculateDamage(attacker.Stats["Attack"]));
        defender.TakeDamage(attackerDamage);
    }
    
    public void CheckWinnner(Pokemon attacker, Pokemon defender)
    {
        if (defender.Stats["HP"] <= 0)
        {
            PokemonBattleInfo.CombatWinner = $"{attacker.Name["english"]}";
        }
    }
}