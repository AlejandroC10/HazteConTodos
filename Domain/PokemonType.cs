namespace Domain;

public class PokemonType
{
    static Dictionary<string, double> steelType = new()
    {
      {"Steel", 0.5},
      {"Water", 0.5},
      {"Bug", 1},
      {"Dragon", 1},
      {"Electric", 0.5},
      {"Ghost", 1},
      {"Fire", 0.5},
      {"Fairy", 2},
      {"Ice", 2},
      {"Fight", 1},
      {"Normal", 1},
      {"Grass", 1},
      {"Psychic", 1},
      {"Rock", 2},
      {"Dark", 1},
      {"Ground", 1},
      {"Poison", 1},
      {"Fly", 1}
    };
    static Dictionary<string, double> waterType = new()
    {
      {"Steel", 1},
      {"Water", 0.5},
      {"Bug", 1},
      {"Dragon", 0.5},
      {"Electric", 1},
      {"Ghost", 1},
      {"Fire", 2},
      {"Fairy", 1},
      {"Ice", 1},
      {"Fight", 1},
      {"Normal", 1},
      {"Grass", 0.5},
      {"Psychic", 1},
      {"Rock", 2},
      {"Dark", 1},
      {"Ground", 2},
      {"Poison", 1},
      {"Fly", 1}
    };
    static Dictionary<string, double> bugType = new()
    {
      {"Steel", 0.5},
      {"Water", 1},
      {"Bug", 1},
      {"Dragon", 1},
      {"Electric", 1},
      {"Ghost", 0.5},
      {"Fire", 0.5},
      {"Fairy", 0.5},
      {"Ice", 1},
      {"Fight", 0.5},
      {"Normal", 1},
      {"Grass", 2},
      {"Psychic", 2},
      {"Rock", 1},
      {"Dark", 2},
      {"Ground", 1},
      {"Poison", 0.5},
      {"Fly", 0.5}
    };
    static Dictionary<string, double> dragonType = new()
    {
      {"Steel", 0.5},
      {"Water", 1},
      {"Bug", 1},
      {"Dragon", 2},
      {"Electric", 1},
      {"Ghost", 1},
      {"Fire", 1},
      {"Fairy", 0},
      {"Ice", 1},
      {"Fight", 1},
      {"Normal", 1},
      {"Grass", 1},
      {"Psychic", 1},
      {"Rock", 1},
      {"Dark", 1},
      {"Ground", 1},
      {"Poison", 1},
      {"Fly", 1}
    };
    static Dictionary<string, double> electricType = new()
    {
      {"Steel", 1},
      {"Water", 2},
      {"Bug", 1},
      {"Dragon", 1},
      {"Electric", 1},
      {"Ghost", 1},
      {"Fire", 1},
      {"Fairy", 1},
      {"Ice", 1},
      {"Fight", 1},
      {"Normal", 1},
      {"Grass", 0.5},
      {"Psychic", 1},
      {"Rock", 1},
      {"Dark", 1},
      {"Ground", 0},
      {"Poison", 1},
      {"Fly", 2}
    };
    static Dictionary<string, double> ghostType = new()
    {
      {"Steel", 1},
      {"Water", 1},
      {"Bug", 1},
      {"Dragon", 1},
      {"Electric", 1},
      {"Ghost", 1},
      {"Fire", 1},
      {"Fairy", 1},
      {"Ice", 1},
      {"Fight", 1},
      {"Normal", 0},
      {"Grass", 1},
      {"Psychic", 2},
      {"Rock", 1},
      {"Dark", 0.5},
      {"Ground", 1},
      {"Poison", 1},
      {"Fly", 1}
    };
    static Dictionary<string, double> fireType = new()
    {
      {"Steel", 2},
      {"Water", 0.5},
      {"Bug", 2},
      {"Dragon", 0.5},
      {"Electric", 1},
      {"Ghost", 1},
      {"Fire", 0.5},
      {"Fairy", 1},
      {"Ice", 2},
      {"Fight", 1},
      {"Normal", 1},
      {"Grass", 2},
      {"Psychic", 1},
      {"Rock", 0.5},
      {"Dark", 1},
      {"Ground", 1},
      {"Poison", 1},
      {"Fly", 1}
    };
    static Dictionary<string, double> fairyType = new()
    {
      {"Steel", 0.5},
      {"Water", 1},
      {"Bug", 1},
      {"Dragon", 2},
      {"Electric", 1},
      {"Ghost", 1},
      {"Fire", 0.5},
      {"Fairy", 1},
      {"Ice", 1},
      {"Fight", 2},
      {"Normal", 1},
      {"Grass", 1},
      {"Psychic", 1},
      {"Rock", 1},
      {"Dark", 2},
      {"Ground", 1},
      {"Poison", 0.5},
      {"Fly", 1}
    };
    static Dictionary<string, double> iceType = new()
    {
      {"Steel", 0.5},
      {"Water", 0.5},
      {"Bug", 1},
      {"Dragon", 2},
      {"Electric", 1},
      {"Ghost", 1},
      {"Fire", 0.5},
      {"Fairy", 1},
      {"Ice", 0.5},
      {"Fight", 1},
      {"Normal", 1},
      {"Grass", 2},
      {"Psychic", 1},
      {"Rock", 1},
      {"Dark", 1},
      {"Ground", 2},
      {"Poison", 1},
      {"Fly", 2}
    };
    static Dictionary<string, double> fightType = new()
    {
      {"Steel", 2},
      {"Water", 1},
      {"Bug", 0.5},
      {"Dragon", 1},
      {"Electric", 1},
      {"Ghost", 0},
      {"Fire", 1},
      {"Fairy", 0.5},
      {"Ice", 2},
      {"Fight", 1},
      {"Normal", 2},
      {"Grass", 1},
      {"Psychic", 0.5},
      {"Rock", 2},
      {"Dark", 2},
      {"Ground", 1},
      {"Poison", 0.5},
      {"Fly", 0.5}
    };
    static Dictionary<string, double> normalType = new()
    {
      {"Steel", 0.5},
      {"Water", 1},
      {"Bug", 1},
      {"Dragon", 1},
      {"Electric", 1},
      {"Ghost", 0},
      {"Fire", 1},
      {"Fairy", 1},
      {"Ice", 1},
      {"Fight", 1},
      {"Normal", 1},
      {"Grass", 1},
      {"Psychic", 1},
      {"Rock", 0.5},
      {"Dark", 1},
      {"Ground", 1},
      {"Poison", 1},
      {"Fly", 1}
    };
    static Dictionary<string, double> grassType = new()
    {
      {"Steel", 0.5},
      {"Water", 2},
      {"Bug", 0.5},
      {"Dragon", 0.5},
      {"Electric", 1},
      {"Ghost", 1},
      {"Fire", 0.5},
      {"Fairy", 1},
      {"Ice", 1},
      {"Fight", 1},
      {"Normal", 1},
      {"Grass", 0.5},
      {"Psychic", 1},
      {"Rock", 2},
      {"Dark", 1},
      {"Ground", 2},
      {"Poison", 0.5},
      {"Fly", 0.5}
    };
    static Dictionary<string, double> psychicType = new()
    {
      {"Steel", 0.5},
      {"Water", 1},
      {"Bug", 1},
      {"Dragon", 1},
      {"Electric", 1},
      {"Ghost", 1},
      {"Fire", 1},
      {"Fairy", 1},
      {"Ice", 1},
      {"Fight", 2},
      {"Normal", 1},
      {"Grass", 1},
      {"Psychic", 0.5},
      {"Rock", 1},
      {"Dark", 0},
      {"Ground", 1},
      {"Poison", 2},
      {"Fly", 1}
    };
    static Dictionary<string, double> rockType = new()
    {
      {"Steel", 0.5},
      {"Water", 1},
      {"Bug", 2},
      {"Dragon", 1},
      {"Electric", 1},
      {"Ghost", 1},
      {"Fire", 2},
      {"Fairy", 1},
      {"Ice", 2},
      {"Fight", 0.5},
      {"Normal", 1},
      {"Grass", 1},
      {"Psychic", 1},
      {"Rock", 1},
      {"Dark", 1},
      {"Ground", 0.5},
      {"Poison", 1},
      {"Fly", 2}
    };
    static Dictionary<string, double> darkType = new()
    {
      {"Steel", 1},
      {"Water", 1},
      {"Bug", 1},
      {"Dragon", 1},
      {"Electric", 1},
      {"Ghost", 2},
      {"Fire", 1},
      {"Fairy", 0.5},
      {"Ice", 1},
      {"Fight", 0.5},
      {"Normal", 1},
      {"Grass", 1},
      {"Psychic", 2},
      {"Rock", 1},
      {"Dark", 0.5},
      {"Ground", 1},
      {"Poison", 1},
      {"Fly", 1}
    };
    static Dictionary<string, double> groundType = new()
    {
      {"Steel", 2},
      {"Water", 1},
      {"Bug", 0.5},
      {"Dragon", 1},
      {"Electric", 2},
      {"Ghost", 1},
      {"Fire", 2},
      {"Fairy", 1},
      {"Ice", 1},
      {"Fight", 1},
      {"Normal", 1},
      {"Grass", 0.5},
      {"Psychic", 1},
      {"Rock", 2},
      {"Dark", 1},
      {"Ground", 1},
      {"Poison", 2},
      {"Fly", 0}
    };
    static Dictionary<string, double> poisonType = new()
    {
      {"Steel", 0},
      {"Water", 1},
      {"Bug", 1},
      {"Dragon", 1},
      {"Electric", 1},
      {"Ghost", 0.5},
      {"Fire", 1},
      {"Fairy", 2},
      {"Ice", 1},
      {"Fight", 1},
      {"Normal", 1},
      {"Grass", 2},
      {"Psychic", 1},
      {"Rock", 0.5},
      {"Dark", 1},
      {"Ground", 0.5},
      {"Poison", 0.5},
      {"Fly", 1}
    };
    static Dictionary<string, double> flyType = new()
    {
      {"Steel", 0.5},
      {"Water", 1},
      {"Bug", 2},
      {"Dragon", 1},
      {"Electric", 0.5},
      {"Ghost", 1},
      {"Fire", 1},
      {"Fairy", 1},
      {"Ice", 1},
      {"Fight", 2},
      {"Normal", 1},
      {"Grass", 2},
      {"Psychic", 1},
      {"Rock", 0.5},
      {"Dark", 1},
      {"Ground", 1},
      {"Poison", 1},
      {"Fly", 1}
    };

    public static double GetTypeEffectiveness(string attackerType, string defenderType)
    {
        var typeTable = new Dictionary<string, Dictionary<string, double>>()
        {
          {"Steel", steelType},
          {"Water", waterType},
          {"Bug", bugType},
          {"Dragon", dragonType},
          {"Electric", electricType},
          {"Ghost", ghostType},
          {"Fire", fireType},
          {"Fairy", fairyType},
          {"Ice", iceType},
          {"Fight", fightType},
          {"Normal", normalType},
          {"Grass", grassType},
          {"Psychic", psychicType},
          {"Rock", rockType},
          {"Dark", darkType},
          {"Ground", groundType},
          {"Poison", poisonType},
          {"Fly", flyType},
        };

        return typeTable[attackerType][defenderType];
    }
}