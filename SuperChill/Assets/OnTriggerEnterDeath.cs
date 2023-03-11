using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        OnCollisionEnterDeath death = other.GetComponent<OnCollisionEnterDeath>();

        if(death != null)
        {
            death.enemy.Dead(transform.position);
        }
    }

}
