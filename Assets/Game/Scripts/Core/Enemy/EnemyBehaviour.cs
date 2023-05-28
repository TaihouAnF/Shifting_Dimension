using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float detectionDistance;
    [SerializeField] float speed;

    private void Update() 
    {
        if(TargetInRange())
        {
            print("target detercted");
            var steps = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, steps);
        }

        
    }


    bool TargetInRange()
    {
       float targetDistance = Vector3.Distance(target.position, transform.position);

       if (targetDistance < detectionDistance) return true;
       else return false;
    }


   
}
