using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimatorController
{
    public class AnimatorColtroller : MonoBehaviour
    {
        [SerializeField]Animator animator;
        
        private Rigidbody playerRb;
        private PlayerController playerController;
        private bool runIdleIsPlayying;

        void Start()
        {
            playerController = GetComponent<PlayerController>();
            playerRb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            // Running & Idle
            UpdateRunningAnimation(Mathf.Abs(playerRb.velocity.x));

            // Jumping
            UpdateJumpingAnimation(playerRb.velocity.y, playerController.isGrounded);

        }

        public void UpdateRunningAnimation(float playerSpeed) 
        {
            animator.SetFloat("Speed", playerSpeed);
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("RunIdleTrans"))
            {
                runIdleIsPlayying = true;
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                    runIdleIsPlayying = false;
            }
            animator.SetBool("RunIdlePlayying", runIdleIsPlayying);
        }

        public void UpdateJumpingAnimation(float velocityOnY, bool grounded)
        {
            animator.SetBool("Grounded", grounded);
            animator.SetFloat("Yvelocity", velocityOnY);
        }
    }

}

