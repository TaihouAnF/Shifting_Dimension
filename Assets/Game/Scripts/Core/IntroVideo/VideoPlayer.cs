using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoPlayer : MonoBehaviour
{
  [SerializeField] VideoClip video;
  
    public LevelManager levelManager;
    
  

 private void Start() 
 {
    

    Invoke("LoadNextScene", (float)video.length);
    
}





  

  public void LoadNextScene()
  {
    levelManager.LoadNextLevel();
  }
}
