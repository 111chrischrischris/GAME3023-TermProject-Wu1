using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public List<OwnedPokemon> ownedPokemon = new List<OwnedPokemon>();

    public string LastSpawnPointName
    {
        get;
        set;
    } = "";
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(SavingSystem.SaveStart);
        if (SavingSystem.SaveStart)
        {
            PlayerData data = SavingSystem.LoadPlayer();
            Vector2 position = new Vector2(data.position[0], data.position[1]);
            transform.position = position;
        }


#if UNITY_EDITOR
        DestroySelfIfNotOriginal();
#endif


        SceneManager.sceneLoaded += OnSceneLoadAction;

    }

    private void DestroySelfIfNotOriginal()
    {
        if (SpawnPoint.Player != this)
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoadAction(Scene scene, LoadSceneMode loadMode)
    {
        if (LastSpawnPointName != "")
        {
            SpawnPoint[] spawnPoints = GameObject.FindObjectsOfType<SpawnPoint>();
            foreach (SpawnPoint spawn in spawnPoints)
            {
                if (spawn.name == LastSpawnPointName)
                {
                    transform.position = spawn.transform.position;
                }
            }
        }
    }


}

[System.Serializable]
public class OwnedPokemon
{
    public string NickName;
    public BasePokemon pokemon;
    public int level;
    public List<PokemonMoves> moves = new List<PokemonMoves>();
}