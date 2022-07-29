namespace Domain;

public class PokemonInfo
{
    public string PokemonName { get; set; }
    public int PokemonHp { get; set; }

    public PokemonInfo(string pokemonName, int pokemonHp)
    {
        PokemonName = pokemonName;
        PokemonHp = pokemonHp;
    }
}