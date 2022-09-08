using Domain;

namespace Infrastructure;

public interface IPokemonBattleDb
{
    public void SaveBattle(IPokemonBattle pokemonBattle);
    public void DeleteBattle(IPokemonBattle pokemonBattle);
    public void LoadBattle(IPokemonBattle pokemonBattle);
}