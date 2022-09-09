using Domain;

namespace Infrastructure;

public class PokemonBattleHandler
{
    private IPokemonBattleDb pokemonBattleDataBase;
    private IPokemonAttacker pokemonAttacker;

    public PokemonBattleHandler(IPokemonBattleDb pokemonBattleDb, IPokemonAttacker pokemonAtt)
    {
        pokemonBattleDataBase = pokemonBattleDb;
        pokemonAttacker = pokemonAtt;
    }

    public PokemonBattle BattleHandler(Pokemon pokemon1, Pokemon pokemon2)
    {
        var pokemonBattle = new PokemonBattle(pokemonAttacker);
        pokemonBattle.CreateBattle(pokemon1, pokemon2);
        pokemonBattleDataBase.LoadBattle(pokemonBattle);
        pokemonBattle.Combat();


        if (pokemonBattle.PokemonBattleInfo.CombatWinner != null)
        {
            pokemonBattleDataBase.DeleteBattle(pokemonBattle);
        }
        else
        {
            pokemonBattleDataBase.SaveBattle(pokemonBattle);
        }

        return pokemonBattle;
    }
}
