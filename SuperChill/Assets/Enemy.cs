using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    private NavMeshAgent agent;
    public Transform playerTarget;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetupRagdoll();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerTarget.position);
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
