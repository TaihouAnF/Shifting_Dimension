using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {

        [SerializeField] AudioSource jumpAudio;


        public void PlayJumpAudio()
        {
            jumpAudio.Play();
        }
    }
}
