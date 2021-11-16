using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.Processors;

public class Zombie : MonoBehaviour
{
    private HealthComponent _healthComponent;
    private Animator _animator;
    private SightPerceptionComp _sightPerceptionComp;


    void Start()
    {
        _healthComponent = GetComponent<HealthComponent>();
        _animator = GetComponent<Animator>();
        _sightPerceptionComp = GetComponent<SightPerceptionComp>();
        
        
        if (_healthComponent)
        {
            _healthComponent._onDamageTaken += TookDamage;
            _healthComponent._onHitPointDepleted += Dead;
        }
    }

    private void Dead()
    {
        //play dead anim
        Debug.Log("I am dead");
        _animator.SetTrigger("Dead");
    }

    private void TookDamage(int newamt, int oldamt, GameObject Instigator)
    {
        GetComponent<AIController>().SetBlackboardKey("Target", Instigator.transform.position);
        //AlertMode();
    }

   /* private void AlertMode()
    {
        this would have set the sight radius higher
        _sightPerceptionComp.
        transform.LookAt(FindObjectOfType<Player>().transform.position);
    }*/

    public void DeathAnimationFinished()
    {
        Invoke("DestroySelf",1);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}