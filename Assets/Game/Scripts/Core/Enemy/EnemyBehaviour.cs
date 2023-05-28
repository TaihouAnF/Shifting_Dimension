using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float detectionDistance;
    [SerializeField] float speed;
    Rigidbody rb;
    SpriteRenderer sprite;
    [SerializeField] Transform startingPoint;
    [SerializeField] Transform explosionPoint;
    Animator animator;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        MoveTowarsPlayer();
        GoBackToStartingPoint();

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

    }

    private void MoveTowarsPlayer()
    {
        if (TargetInRange())
        {
            Vector3 direction = (target.position - transform.position).normalized;



            rb.velocity = direction * speed;



            if (direction.x < 0)
            {
                sprite.flipX = false;
            }
            else
                sprite.flipX = true;

        }

    }

    bool TargetInRange()
    {
       float targetDistance = Vector3.Distance(target.position, transform.position);

       if (targetDistance < detectionDistance) return true;
       else return false;
    }

    void GoBackToStartingPoint()
    {
        
    if (!TargetInRange() && startingPoint != null)
     {
            float distance = Vector3.Distance(transform.position, startingPoint.position);
            
         if( distance > 3f)
        {
                
            Vector3 direction = (startingPoint.position - transform.position).normalized;

            if(direction.x > 0)
            {
                sprite.flipX =  true;
            }
            else
                    sprite.flipX = false;


            rb.velocity = direction * speed;

         }
    }

    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {
            animator.SetTrigger("Punch");
            StartCoroutine(Punch());

            
            
        }
        IEnumerator Punch()
        {
            yield return new WaitForSeconds(0.1f);
            other.gameObject.GetComponent<PlayerController>().Collision();
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

            rb.AddExplosionForce(1000, explosionPoint.position, 5f, 0, ForceMode.Impulse);
            rb.AddExplosionForce(1000, explosionPoint.position, 5f, 50, ForceMode.Impulse);

        }
        
    }

    



   
}
