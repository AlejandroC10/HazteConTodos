using Domain;

namespace Application;

public interface IPokedex
{
    public Pokemon FindPokemonById(int id);
    public List<Pokemon> FindPokemonByType(string type);
    public List<Pokemon> FindAllPokemon();
    public void DeletePokemonById(int id);
}