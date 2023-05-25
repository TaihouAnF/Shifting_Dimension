using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {

        [SerializeField] AudioSource jumpAudio;
        [SerializeField] AudioSource runAudio;

        public void PlayJumpAudio()
        {
            jumpAudio.Play();
        }

        public void PlayRunAudio()
        {
            runAudio.Play();
        }

        public void StopRunAudio()
        {
            runAudio.Stop();
        }
    }
}
