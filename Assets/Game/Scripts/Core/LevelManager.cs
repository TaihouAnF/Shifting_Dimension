using System.Collections;
using System.Collections.Generic;
using Audio;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    public TextMeshProUGUI switchSceneText;
    public bool readyToNext;
    private PlayerController player;
    
    
    protected virtual void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        readyToNext = false;
        if (switchSceneText)
        {
            switchSceneText.gameObject.SetActive(false);
        }
        player = GameObject.Find("Player") ? GameObject.Find("Player").GetComponent<PlayerController>() : null;
    }

    void Update()
    {
        if (player)
        {
            if (player.isGameOver && SceneManager.GetActiveScene().buildIndex == 2)
            {
                RestartScene();
            }

            if (readyToNext)
            {
                switchSceneText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.R))
                {
                    GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlayPortalSound();
                    StartCoroutine(LoadNextLevelAfterSound());
                    
                }
            }
        }
    }

    // This can be modified in the future if we have more levels
    public void LoadNextLevel()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        buildIndex++;
        SceneManager.LoadScene(buildIndex);
        
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator LoadNextLevelAfterSound()
    {
        yield return new WaitForSeconds(0.8f);
        LoadNextLevel();

    }
}
