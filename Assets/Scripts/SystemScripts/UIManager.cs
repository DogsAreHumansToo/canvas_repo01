using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject inGameUI;
    public bool toggleInGameUIOnDeath;
    public TextMeshProUGUI goalUI;
    public GameSystem gameSystem;

    private void Update()
    {
        if(gameSystem.waveLevel)
        {
            int enemyCounter = gameSystem.maxEnemies - gameSystem.enemiesKilled;
            goalUI.text = "x" + enemyCounter.ToString();
        }
        else if (gameSystem.timeLevel)
        {
            int timer = (int)gameSystem.enemySpawner.targetTime;
            goalUI.text = timer.ToString() + "s left";
        }

        //if(Input.GetKeyDown(KeyCode.Escape))
        //{
        //    SceneManager.LoadScene(0);
        //}
    }

    private void OnEnable()
    {
        HealthScript.onPlayerDeath += EnableGameOverMenu;
    }
    
    private void OnDisable()
    {
        HealthScript.onPlayerDeath -= EnableGameOverMenu;
        
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);

        if(toggleInGameUIOnDeath)
        {
            inGameUI.SetActive(false);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
