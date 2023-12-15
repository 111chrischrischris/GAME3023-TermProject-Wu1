using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public GameObject PlayerFile;
    public void SavePlayer()
    {
        SavingSystem.SavePlayer(PlayerFile.GetComponent<Player>());
    }

    public void LoadPlayer()
    {
        PlayerData data = SavingSystem.LoadPlayer();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
