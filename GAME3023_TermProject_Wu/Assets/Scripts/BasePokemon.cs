using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePokemon : MonoBehaviour
{
    public string Name;
    public Sprite image;
    public BiomeList biomeFound;
    public PokemonType type;
    public Rarity rarity;
    public int HP;
    private int maxHP;
    public Stat AttackStat;
    public Stat DefenceStat;

    public PokemonStats pokemonStats;

    public bool canEvolve;
    public PokemonEvolution evolveTo;

    private int level;

    void Start()
    {
        maxHP = HP;
    }

    public void AddMember(BasePokemon bp)
    {
        this.name = bp.name;
        this.image = bp.image;
        this.biomeFound = bp.biomeFound;
        this.type = bp.type; ;
        this.rarity = bp.rarity;
        this.HP = bp.HP;
        this.maxHP = bp.maxHP;
        this.AttackStat = bp.AttackStat;
        this.DefenceStat = bp.DefenceStat;
        this.pokemonStats = bp.pokemonStats;   
        this.canEvolve = bp.canEvolve; 
        this.evolveTo = bp.evolveTo;
        this.level = bp.level;
    }
}


public enum Rarity
{
    VeryCommon,
    Common,
    SemiRare,
    Rare,
    VeryRare
}

public enum PokemonType
{
    Flying,
    Ground,
    Rock,
    Steel,
    Fire,
    Water,
    Grass,
    Ice,
    Electric,
    Psychic,
    Dark,
    Dragon,
    Ghost,
    Fairy,
    Normal,
    Fighting,
    Poison,
    Bug
}

[System.Serializable]
public class PokemonEvolution
{
    public BasePokemon nextEvolution;
    public int levelUpLevel;
}

[System.Serializable]
public class PokemonStats
{
    public int AttackStat;
    public int DefenceStat;
    public int SpeedStat;
    public int SpAttackStat;
    public int SpDefenceStat;
    public int EvasionStat;
}