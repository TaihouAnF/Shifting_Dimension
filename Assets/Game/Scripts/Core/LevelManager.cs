using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        instance = this;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene("Level_1");
    }
}
