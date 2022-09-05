namespace Domain;

public class PokemonBattle
{
    public List<Pokemon> SelectedPokemon { get; set; }
    public string? CombatWinner { get; set; }
    public string CombatStatus { get; set; }

    public PokemonBattle()
    {
        CombatStatus = "";
    }

    public void CreateBattle(Pokemon pokemonOne, Pokemon pokemonTwo)
    {
        SelectedPokemon = new List<Pokemon> { pokemonOne, pokemonTwo };
    }
    
    public void SaveBattle()
    {
        throw new NotImplementedException();
    }
}