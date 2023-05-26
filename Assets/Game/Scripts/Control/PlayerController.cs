using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using Audio;
using UnityEditor.Experimental.GraphView;
using AnimatorController;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;         // Speed of how fast the player moves, can be set on inspector
    public float jumpForce;         // Jump force on the player, can be set on inspector
    public bool isGameOver = false; // Flag to gameover or not
    public bool realOrShadow = true; // Flag to indicate dimension, true is real; false is shadow
    public SpriteRenderer playerSpriteRen;
    public bool isGrounded = true;
    
    
    public ParticleSystem shadowNotification;

    private AudioManager audioManager;  // AudioManager
    private Rigidbody playerRb;     // Player Rigidbody
    private Animator playerAnim;    // Player Animation for running/jumping/switching
    public float gravityMulti;
    //private bool runIdleIsPlayying; 


    // private GameManagerDependencyInfo gameManager; // A game manager for getting status of the player /* Uncomment it if we have one */


    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityMulti;
        // gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); /* Uncomment it if we have one */
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = OnTheGround();

        #region IDLE & RUN
        // Movement And we want to use physics so we utilize velocity instead of translate
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.velocity = new Vector2(horizontalInput * moveSpeed, playerRb.velocity.y);
        // if (Mathf.Abs(playerRb.velocity.x) > 0 && isGrounded)
        // {
        //     audioManager.PlayRunAudio();
        // }
        // else
        // {
        //     audioManager.StopRunAudio();
        // }

        if (playerRb.velocity.x < 0)
        {
            playerSpriteRen.flipX = true;
        }
        else if (playerRb.velocity.x > 0 && playerSpriteRen.flipX)
        {
            playerSpriteRen.flipX = false;
        }

        #endregion

        #region JUMP
        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            audioManager.PlayJumpAudio();
            playerRb.velocity = new Vector3(playerRb.velocity.x, jumpForce, 0);
            isGrounded = false;
        }
        #endregion

        #region SWITCH
        // Switching, the player would be blue
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (realOrShadow)
            {
                realOrShadow = false;
                playerSpriteRen.color = new Color(0.5f, 0.5f, 1f);
                shadowNotification.Play();
            }
            else
            {
                realOrShadow = true;
                playerSpriteRen.color = new Color(1f, 1f, 1f);
                shadowNotification.Stop();
            }
        }
        #endregion
    }

    private bool OnTheGround()// this bools checks if we are on the ground, used to make sure we are not double jumping
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 3.5f, 1 << 8))
        {
            return hit.collider.gameObject.CompareTag("Walkable") ||
                   (hit.collider.gameObject.CompareTag("WalkableR") && realOrShadow) ||
                   (hit.collider.gameObject.CompareTag("WalkableS") && !realOrShadow);
        }
        return false;
               
    }
}
