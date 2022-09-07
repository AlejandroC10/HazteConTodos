using System.Text.Json.Serialization;

namespace Domain;

public class Pokemon
{
  [JsonPropertyName("id")]
  public int Id { get; set; }
  
  [JsonPropertyName("name")]
  public Dictionary<string, string> Name { get; set; }
  
  [JsonPropertyName("type")]
  public List<string> Type { get; set; }

  [JsonPropertyName("stats")]
  public Dictionary<string, int> Stats { get; set; }

  public Pokemon(int id, Dictionary<string,string> name, List<string> type, Dictionary<string,int> stats)
  {
    Id = id;
    Name = name;
    Type = type;
    Stats = stats;
  }

  public void TakeDamage(int damage)
  {
    Stats["HP"] -= damage;
  }

  public int CalculateDamage(List<string> pokemon2Type, int damage)
  {
    var damageVariator = PokemonType.GetTypeEffectiveness(Type[0], pokemon2Type[0]);
    return (int)(damage * damageVariator);
  }
}