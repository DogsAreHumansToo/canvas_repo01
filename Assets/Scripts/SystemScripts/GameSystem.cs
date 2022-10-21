using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameSystem : MonoBehaviour
{

    public bool waveLevel = false;
    public int enemiesKilled = 0;
    public GameObject completeLevelUI;

    private void Update()
    {
        if (waveLevel)
        {
            if (enemiesKilled >= 7)
            {
                Debug.Log("WIN!!!!!!!!!!!!!!!");
                enemiesKilled = 0;
                completeLevelUI.SetActive(true);
            }
        }
    }
}
