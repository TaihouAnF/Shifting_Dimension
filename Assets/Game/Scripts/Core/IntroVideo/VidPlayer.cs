using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour
{
    [SerializeField] VideoClip video;
    [SerializeField] string videoFileName;
    public LevelManager levelManager;
    
  

 private void Start() 
 {

        PlayVideo();
        Invoke("LoadNextScene", (float)video.length);
    
}


    public void PlayVideo()
    {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();
        if (videoPlayer)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            videoPlayer.url = videoPath;
            videoPlayer.Play();
        }
    }


  

  public void LoadNextScene()
  {
    levelManager.LoadNextLevel();
  }
}
