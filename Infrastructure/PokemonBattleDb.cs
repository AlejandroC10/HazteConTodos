using System.Text.Json;
using Domain;

namespace Infrastructure;

public class PokemonBattleDb: IPokemonBattleDb
{
    public void SaveBattle(PokemonBattle pokemonBattle)
    {
        var pokemonOne = pokemonBattle.PokemonBattleInfo.SelectedPokemon[0].Id;
        var pokemonTwo = pokemonBattle.PokemonBattleInfo.SelectedPokemon[1].Id;
        
        var jsonContent = JsonSerializer.Serialize<PokemonBattleInfo>(pokemonBattle.PokemonBattleInfo);
        var path = AppDomain.CurrentDomain.BaseDirectory;
        File.WriteAllText(Path.Combine(path, $"{pokemonOne}vs{pokemonTwo}.json"), jsonContent);
    }

    public void DeleteBattle(PokemonBattle pokemonBattle)
    {
        var pokemonOne = pokemonBattle.PokemonBattleInfo.SelectedPokemon[0].Id;
        var pokemonTwo = pokemonBattle.PokemonBattleInfo.SelectedPokemon[1].Id;
        
        var path = AppDomain.CurrentDomain.BaseDirectory;
        File.Delete(Path.Combine(path, $"{pokemonOne}vs{pokemonTwo}.json"));
    }
    
    public void LoadBattle(PokemonBattle pokemonBattle)
    {
        throw new NotImplementedException();
    }
}