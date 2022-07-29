namespace Domain;

public class CombatInfo
{
    public List<PokemonInfo> PokemonInfo { get; set; }
    public string? CombatWinner { get; set; }
    
    public CombatInfo(List<PokemonInfo> pokemonInfo, string combatWinner)
    {
        PokemonInfo = pokemonInfo;
        CombatWinner = combatWinner;
    }
}