using System;
using System.IO;
using System.Text.Json;
using Domain;

namespace Infrastructure.Tests;

public class PokemonBattleDbTest: IPokemonBattleDb
{
    public void SaveBattle(IPokemonBattle pokemonBattle)
    {
        var pokemonOne = pokemonBattle.PokemonBattleInfo.SelectedPokemon[0].Id;
        var pokemonTwo = pokemonBattle.PokemonBattleInfo.SelectedPokemon[1].Id;
        
        var jsonContent = JsonSerializer.Serialize<PokemonBattleInfo>(pokemonBattle.PokemonBattleInfo);
        var path = AppDomain.CurrentDomain.BaseDirectory;
        File.WriteAllText(Path.Combine(path, $"{pokemonOne}vs{pokemonTwo}.test.json"), jsonContent);
    }

    public void DeleteBattle(IPokemonBattle pokemonBattle)
    {
        var pokemonOne = pokemonBattle.PokemonBattleInfo.SelectedPokemon[0].Id;
        var pokemonTwo = pokemonBattle.PokemonBattleInfo.SelectedPokemon[1].Id;
        
        var path = AppDomain.CurrentDomain.BaseDirectory;
        File.Delete(Path.Combine(path, $"{pokemonOne}vs{pokemonTwo}.test.json"));
    }
    
    public void LoadBattle(IPokemonBattle pokemonBattle)
    {
        var pokemonOne = pokemonBattle.PokemonBattleInfo.SelectedPokemon[0].Id;
        var pokemonTwo = pokemonBattle.PokemonBattleInfo.SelectedPokemon[1].Id;
        var path = AppDomain.CurrentDomain.BaseDirectory;
        var filePath = Path.Combine(path, $"{pokemonOne}vs{pokemonTwo}.test.json");
        
        if (File.Exists(filePath))
        {
            DeleteBattle(pokemonBattle);
        }
    }
}