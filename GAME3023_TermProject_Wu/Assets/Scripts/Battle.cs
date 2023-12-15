using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Battle : MonoBehaviour
{
    public Transform defencePodium;
    public Transform attackPodium;
    public GameObject emptyPoke;

    public List<BasePokemon> allPokemon = new List<BasePokemon>();
    public List<PokemonMoves> allMoves = new List<PokemonMoves>();

    public BattleManager bm;


    public void EnterBattle(Rarity rarity)
    {
        BasePokemon battlePokemon = GetRandomPokemonFromList(GetPokemonByRarity(rarity));
        GameObject dPoke = Instantiate(emptyPoke, defencePodium.transform.position, Quaternion.identity);

        Vector3 pokeLocalPos = new Vector3(0, 1, 0);

        dPoke.transform.parent = defencePodium;
        dPoke.transform.localPosition = pokeLocalPos;

        BasePokemon tempPoke = dPoke.AddComponent<BasePokemon>() as BasePokemon;
        tempPoke.AddMember(battlePokemon);

        dPoke.GetComponent<SpriteRenderer>().sprite = battlePokemon.image;

        bm.ChangeMenu(BattleMenu.Selection);
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
