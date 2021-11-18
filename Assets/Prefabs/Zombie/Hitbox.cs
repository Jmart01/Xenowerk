using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthComponent playerHealth = other.GetComponent<HealthComponent>();
            playerHealth.TakeDamage(1,this.gameObject);
        }
    }
}
