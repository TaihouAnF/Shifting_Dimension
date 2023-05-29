using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;

public class ShooterBehaviour : EnemyBehaviour
{
   public GameObject projectilePrefab;
   public Transform projectilePrefabSpawnPoint;
   [SerializeField] float attackSpeed;
   float timeSinceLastAttack = 0;
   bool canAttack = true;
   AudioManager audioManager;

public override void Start() 
{
    base.Start();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    
}

    public override void Update()
    {
        Attacking();
        AttackCoolDown();

    }

    private void Attacking()
    {
        if (TargetInRange() && canAttack)
        {
            Instantiate(projectilePrefab, projectilePrefabSpawnPoint);
            audioManager.PlayBeamAudio();
            canAttack = false;
            timeSinceLastAttack = 0;
            GetComponentInChildren<Animator>().SetBool("Shooting", true);

        }
        else
        {
   
            GetComponentInChildren<Animator>().SetBool("Shooting", false);

        }
        timeSinceLastAttack += Time.deltaTime;
        
    }

    public override void OnCollisionEnter(Collision other)
    {
       
    }

    private void AttackCoolDown()
    {
        if(timeSinceLastAttack >= attackSpeed)
        {
            canAttack = true;
        }
    }

   
}
