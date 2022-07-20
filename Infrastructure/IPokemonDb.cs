using Domain;

namespace Json;

public interface IPokemonDb
{
    public List<Pokemon> ReadPokemon();
    void DeletePokemon(int id);
}