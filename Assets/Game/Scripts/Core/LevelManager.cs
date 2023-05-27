using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    public TextMeshProUGUI switchSceneText;
    public bool readyToNext;
    
    
    protected virtual void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        readyToNext = false;
        switchSceneText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (readyToNext)
        {
            switchSceneText.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R)) 
            { 
                LoadNextLevel();
            }
        }
    }

    // This can be modified in the future if we have more levels
    public void LoadNextLevel()
    {
        SceneManager.LoadScene("Level_1");
    }
}
