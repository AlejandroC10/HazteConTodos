namespace Domain;

public class CombatInfo
{
    public List<PokemonInfo> PokemonInfo { get; set; }
    public string? CombatWinner { get; set; }
    public string CombatStatus { get; set; }

    public CombatInfo(List<PokemonInfo> pokemonInfo, string combatWinner)
    {
        PokemonInfo = pokemonInfo;
        CombatWinner = combatWinner;
        CombatStatus = $"{PokemonInfo[0].PokemonName}: {PokemonInfo[0].PokemonHp} HP | {PokemonInfo[1].PokemonName}: {PokemonInfo[1].PokemonHp} HP";
    }
}