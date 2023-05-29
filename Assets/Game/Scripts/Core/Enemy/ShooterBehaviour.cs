using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBehaviour : EnemyBehaviour
{
   public GameObject projectilePrefab;
   [SerializeField] float attackSpeed;

   public override void Start() 
   {
    base.Start();
    StartCoroutine(Attack());

    
   }

    
    public override void Update()
    {
        
        
    }


    public override void OnCollisionEnter(Collision other)
    {
       
    }

    IEnumerator Attack()
    {
        while(TargetInRange())
        yield return new WaitForSeconds(attackSpeed);
        print("Attacking");
    }
}
