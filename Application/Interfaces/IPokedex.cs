using Domain;

namespace Application.Interfaces;

public interface IPokedex
{
    public Pokemon FindPokemonById(int id);
    public List<Pokemon> FindByType(string type);
    public List<Pokemon> GetAll();

}