using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnDamageTaken(int newAmt, int OldAmt);

public delegate void OnHitPointDepleted();
public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int hitPoint;
    public OnDamageTaken _onDamageTaken;
    public OnHitPointDepleted _onHitPointDepleted;
    
    private void OnParticleCollision(GameObject other)
    {
        Weapon weapon = other.GetComponentInParent<Weapon>();
        if (weapon != null)
        {
            TakeDamage(weapon.GetBulletDmg());
        }
    }

    void TakeDamage(int amt)
    {
        int OldValue = hitPoint;
        hitPoint -= amt;
        if (hitPoint <= 0)
        {
            hitPoint = 0;
            if (_onHitPointDepleted != null)
            {
                _onHitPointDepleted.Invoke();
            }
            //need to die
        }
        else
        {
            //notify dmg taken
            if (OldValue != hitPoint)
            {
                if (_onDamageTaken != null)
                {
                    _onDamageTaken.Invoke(hitPoint, OldValue);
                }
            }
        }
    }
}
