using System.Text.Json;

namespace Domain;

public interface IPokemonBattle
{
    public PokemonBattleInfo PokemonBattleInfo { get; set; }
    public IPokemonAttacker PokemonAttacker { get; set; }
    
    public void CreateBattle(Pokemon pokemonOne, Pokemon pokemonTwo)
    {
    }

    public void Combat()
    {
    }

    public void Attack(Pokemon attacker, Pokemon defender)
    {
    }
    
    public void CheckWinner(Pokemon attacker, Pokemon defender)
    {
    }
}