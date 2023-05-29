using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    Rigidbody rb;
    GameObject target;
    [SerializeField] float projectileSpeed;
    void Start() 
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("Player");
        Vector3 direction = target.transform.position - transform.position;
        

         rb.velocity = (direction).normalized;
         rb.velocity *= projectileSpeed;

       

        

        Destroy(gameObject, 3f);
        
    }
    

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().Collision();
            Destroy(gameObject);
            
        }
        else
        Destroy(gameObject);
   
    }

    
}
