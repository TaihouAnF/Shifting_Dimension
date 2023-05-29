using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBehaviour : EnemyBehaviour
{
   public GameObject projectilePrefab;
   [SerializeField] float attackSpeed;
   float timeSinceLastAttack = 0;
   bool canAttack = true;


    public override void Update()
    {
        Attacking();
        AttackCoolDown();

    }

    private void Attacking()
    {
        if (TargetInRange() && canAttack)
        {
            print("attacking");
            canAttack = false;
            timeSinceLastAttack = 0;

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
