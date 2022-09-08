namespace Domain;

public class PokemonBattleInfo
{
    public PokemonBattleInfo()
    {
        CombatStatus = "";
    }

    public List<Pokemon> SelectedPokemon { get; set; }
    public string? CombatWinner { get; set; }
    public string CombatStatus { get; set; }
}