using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject WinMenu;

    private void OnEnable()
    {
        HealthScript.onPlayerDeath += EnableGameOverMenu;
        EnemyHitBox.playerWin += EnableWinMenu;
    }
    
    private void OnDisable()
    {
        HealthScript.onPlayerDeath -= EnableGameOverMenu;
        EnemyHitBox.playerWin -= EnableWinMenu;
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
    public void EnableWinMenu()
    {
        WinMenu.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
