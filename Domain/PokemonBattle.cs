using System.Text.Json;

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
        PokemonBattleInfo.SelectedPokemon = new List<Pokemon> { pokemonOne, pokemonTwo };
    }

    public void Combat()
    {
        var pokemonOne = PokemonBattleInfo.SelectedPokemon[0];
        var pokemonTwo = PokemonBattleInfo.SelectedPokemon[1];

        Attack(pokemonOne,pokemonTwo);
        CheckWinner(pokemonOne, pokemonTwo);
        
        if (PokemonBattleInfo.CombatWinner is null)
        {
            Attack(pokemonTwo,pokemonOne);
            CheckWinner(pokemonTwo, pokemonOne);
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
    
    public void CheckWinner(Pokemon attacker, Pokemon defender)
    {
        if (defender.Stats["HP"] <= 0)
        {
            PokemonBattleInfo.CombatWinner = $"{attacker.Name["english"]}";
        }
    }
}