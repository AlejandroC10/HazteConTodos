﻿using System.Text.Json.Serialization;

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

  public int CalculateDamage(List<string> pokemon2Type)
  {
    if (pokemon2Type.Contains("Fire"))
    {
      return 22;
    }

    if (pokemon2Type.Contains("Water"))
    {
      return 52;
    }
    return 37;
  }
}