using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimatorController
{
    public class AnimatorColtroller : MonoBehaviour
    {
        [SerializeField]Animator animator;

        

       public void UpdateRunningAnimation(float playerSpeed) 
       {
        animator.SetFloat("Speed", playerSpeed);
   
       }
    }

}

