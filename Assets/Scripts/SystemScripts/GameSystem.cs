using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameSystem : MonoBehaviour
{
    public int maxEnemies;
    public bool waveLevel = false;
    public int enemiesKilled = 0;
    public GameObject completeLevelUI;
    public GameObject player;

    private void Update()
    {
        if (waveLevel)
        {
            if (enemiesKilled >= maxEnemies)
            {
                Debug.Log("WIN!!!!!!!!!!!!!!!");
                enemiesKilled = 0;
                player.SetActive(false);
                completeLevelUI.SetActive(true);
            }
        }
    }
}
