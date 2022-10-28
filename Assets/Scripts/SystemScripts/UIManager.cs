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
    public TextMeshProUGUI waveUI;
    public GameSystem gameSystem;

    private void Update()
    {
        int enemyCounter = gameSystem.maxEnemies - gameSystem.enemiesKilled;
        waveUI.text = enemyCounter.ToString() + " Enemies Left";
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
