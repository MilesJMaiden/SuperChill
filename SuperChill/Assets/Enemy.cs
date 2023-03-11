using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public FireBulletOnActivate gun;

    private NavMeshAgent agent;
    private Animator animator;
    public Transform playerTarget;

    public float stopDistance = 6f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); 
        SetupRagdoll();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerTarget.position);

        float distance = Vector3.Distance(playerTarget.position, transform.position);  
        if (distance < stopDistance)
        {
            agent.isStopped = true;
            animator.SetBool("Shoot", true);
        }
    }

    public void ShootEnemy()
    {
        gun.FireBullet();
    }

    public void SetupRagdoll()
    {
        //loop through all limbs
        foreach (var item in GetComponentsInChildren<Rigidbody>())
        {
            item.isKinematic = true;
        }
    }

    public void Dead(Vector3 hitPosition)
    {
        //loop through all limbs
        foreach (var item in GetComponentsInChildren<Rigidbody>())
        {
            item.isKinematic = true;
        }

        //Gets all body components within range of hitposition 
        foreach (var item in Physics.OverlapSphere(hitPosition, 0.3f))
        {
            Rigidbody rb = item.GetComponent<Rigidbody>();

            if (rb != null)
            {

                rb.AddExplosionForce(1000, hitPosition, 0.3f);
            }
        }
    }
}
