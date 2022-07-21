using Domain;

namespace Infrastructure;

public interface IPokemonDb
{
    public List<Pokemon> ReadPokemon();
    void DeletePokemon(int id);
    void UpdatePokemon(int id, string key, int change);
}