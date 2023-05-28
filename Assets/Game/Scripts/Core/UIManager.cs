using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image[] healthImage;
    public LevelManager levelManager;


    public void UpdateLives(int livesremaining)
    {
        for (int i = 0; i <= livesremaining; i++)
        {
            if (i == livesremaining)
            {
                healthImage[i].enabled = false;
            }
        }
    }

    public void LoadNextScene()
    {
        levelManager.LoadNextLevel();
    }

    public void RestartScene()
    {
        levelManager.RestartScene();
    }
}
