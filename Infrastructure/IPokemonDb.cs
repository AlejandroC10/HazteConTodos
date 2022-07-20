using Domain;

namespace Infrastructure;

public interface IPokemonDb
{
    public List<Pokemon> ReadPokemon();
    void DeletePokemon(int id);
}