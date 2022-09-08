using Domain;

namespace Infrastructure;

public interface IPokemonBattleDb
{
    public void SaveBattle(PokemonBattle pokemonBattle);
}