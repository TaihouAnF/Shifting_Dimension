using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {

        [SerializeField] AudioSource jumpAudio;
        [SerializeField] AudioSource runAudio;
        [SerializeField] AudioSource switchAudio;
        [SerializeField] AudioSource beamAudio;
        [SerializeField] AudioSource damageTaken;
        [SerializeField] AudioSource deathSound;
        [SerializeField] AudioSource portalSound;

        public void PlayJumpAudio()
        {
            jumpAudio.Play();
        }

        public void PlaySwitchAudio()
        {
            switchAudio.Play();
        }

        public void PlayRunAudio()
        {
            if (!runAudio.isPlaying)
            {
                runAudio.Play();
            }
        }

        public void StopRunAudio()
        {
            if (runAudio.isPlaying) 
            { 
                runAudio.Stop();
            }
        }
        public void PlayBeamAudio()
        {
            beamAudio.Play();
        }

        public void PlayDamageTakenAudio()
        {
            damageTaken.Play();
        }

        public void DeathSound()
        {
            deathSound.Play();
        }

        public void PlayPortalSound()
        {
            portalSound.Play();
        }
    }
}
