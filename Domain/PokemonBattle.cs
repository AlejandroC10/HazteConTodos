namespace Domain;

public class PokemonBattle
{
    public List<Pokemon> SelectedPokemon { get; set; }
    public string? CombatWinner { get; set; }
    public string CombatStatus { get; set; }

    public PokemonBattle(Pokemon pokemonOne, Pokemon pokemonTwo)
    {
        SelectedPokemon = new List<Pokemon> { pokemonOne, pokemonTwo };
        CombatStatus = $"{SelectedPokemon[0].Name["english"]}: {SelectedPokemon[0].Stats["HP"]} HP | {SelectedPokemon[1].Name["english"]}: {SelectedPokemon[1].Stats["HP"]} HP";
    }
}