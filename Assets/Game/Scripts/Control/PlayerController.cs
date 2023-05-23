using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using Audio;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;         // Speed of how fast the player moves, can be set on inspector
    public float jumpForce;         // Jump force on the player, can be set on inspector
    // public bool resetJump;       // Detect whether player should be able to jump or not/avoid unlimited jumping
    public bool isGameOver = false; // Flag to gameover or not
    public float speedThreshold;    // A Threshold to detect whether it's running or not
    public SpriteRenderer playerSpriteRen;
    
    // public bool dashing = false;    // Flag to Dash ability               /* Uncomment it if we want to add */
    // public bool doubleJump = true;  // Flag to Double jumping

    AudioManager audioManager;
    
    
    public AudioClip runSound;      // Sound Clip for running
    public AudioClip switchSound;   // Sound Clip for switching dimension
    public AudioClip dyingSound;    // Sound Clip for dying

    private Rigidbody playerRb; // Player Rigidbody
    private Animator playerAnim;    // Player Animation for running/jumping/switching
    private AudioSource playerAudi; // Player Audio when running/jumping/switching

    
    // private GameManagerDependencyInfo gameManager; // A game manager for getting status of the player /* Uncomment it if we have one */


    // Start is called before the first frame update
    void Start()
    {
        //audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudi = GetComponent<AudioSource>();
        // gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); /* Uncomment it if we have one */
    }

    // Update is called once per frame
    void Update()
    {
        // movement and jump
        Move();

        // Switching
        // if (Input.GetButtonDown("Fire 2"))   // Need to add one more button in the control system
        // {

        //     /* some operations here: switching dimension and stuff */

        //     if (playerAudi.isPlaying) // Make sure the audio stops when switching
        //     {
        //         playerAudi.Stop();
        //     }
        //     // playerAnim.SetTrigger("Switch_trigger") /* Uncomment this if we find running animation */
        //     playerAudi.PlayOneShot(switchSound, 1.0f);
        // }

        if (isGameOver)
        {
            /* player Animation when die */
            // if (playerAudi.isPlaying) // Make sure the audio stops when switching
            // {
            //     playerAudi.Stop();
            // }
            // playerAudi.PlayOneShot(dyingSound, 1.0f);
            // gameManager.GameOver();
        }
    }

    private void Move()
    {
        // Movement And we want to use physics so we utilize velocity instead of translate
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.velocity = new Vector2(horizontalInput * moveSpeed, playerRb.velocity.y);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            print("jump");
            Jumping();
        }

    //     if (IsGrounded() && Mathf.Abs(playerRb2D.velocity.x) > speedThreshold && !playerAudi.isPlaying)
    //     {
    //          playerAnim.SetTrigger("Run_trigger"); /* Uncomment this if we find running animation */
    //         playerAudi.clip = runSound; // Might be another way to make running sound, current implementation doesn't look right
    //         playerAudi.Play();
    //    }
    //     else
    //     {
    //         // playerAnim.SetTrigger("Idle_trigger"); /* Uncomment this if we find running animation */
    //         if (playerAudi != null)
    //         {
    //             playerAudi.Stop();
    //         }
    //     }
        
    }

    private void Jumping()
    {
        playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
        // if (playerAudi.isPlaying) // Make sure the audio stops when jumping
        // {
        //     playerAudi.Stop();
        // }
        // playerAnim.SetTrigger("Jump_trigger"); /* Uncomment this if we find running animation */

        //audioManager.PlayJumpAudio();
        
        
    }

    bool IsGrounded()// this is a bool to check if we are touching the ground
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, 1<<8);  
        return hitinfo.collider != null;
    }

}
