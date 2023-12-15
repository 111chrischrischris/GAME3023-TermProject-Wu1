using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public List<BasePokemon> allPokemon = new List<BasePokemon>();
    public List<PokemonMoves> allMoves = new List<PokemonMoves>();



    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("StartMenu");
        }
    }

    public void EnterBattle(Rarity rarity)
    {
        SceneManager.LoadScene("Battle");
        BasePokemon battlePokemon = GetRandomPokemonFromList(GetPokemonByRarity(rarity));
        player.GetComponent<MovementScript>().isAllowedToMove = false;
    }

    public List<BasePokemon> GetPokemonByRarity(Rarity rarity)
    {
        List<BasePokemon> returnPokemon = new List<BasePokemon>();
        foreach (BasePokemon Pokemon in allPokemon)
        {
            if (Pokemon.rarity == rarity)
                returnPokemon.Add(Pokemon);
        }

        return returnPokemon;
    }

    public BasePokemon GetRandomPokemonFromList(List<BasePokemon> pokeList)
    {
        BasePokemon poke = new BasePokemon();
        int pokeIndex = Random.Range(0, pokeList.Count - 1);
        poke = pokeList[pokeIndex];
        return poke;
    }
}

[System.Serializable]
public class PokemonMoves
{
    string Name;
    public MoveType category;
    public Stat moveStat;
    public PokemonType moveType;
    public int PP;
    public float Power;
    public float accuracy;
}

[System.Serializable]
public class Stat
{
    public float minimum;
    public float maximum;
}

public enum MoveType
{
    Physical,
    Special,
    Status
}
