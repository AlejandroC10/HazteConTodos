namespace Domain;

public class PokemonAttacker: IPokemonAttacker
{
    public int CalculateDamage(int attack)
    {
        return new Random().Next(1, attack); 
    }
}