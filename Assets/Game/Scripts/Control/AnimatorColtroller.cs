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

        void Start()
        {
            playerController = GetComponent<PlayerController>();
            playerRb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            // Jumping
            UpdateJumpingAnimation(playerRb.velocity.y, playerController.isGrounded);

            // Running & Idle
            UpdateRunningAnimation(Mathf.Abs(playerRb.velocity.x));

            

        }

        public void UpdateRunningAnimation(float playerSpeed) 
        {
            animator.SetFloat("Speed", playerSpeed);
        }

        public void UpdateJumpingAnimation(float velocityOnY, bool grounded)
        {
            animator.SetBool("Grounded", grounded);
            animator.SetFloat("Yvelocity", velocityOnY);
        }
    }

}

