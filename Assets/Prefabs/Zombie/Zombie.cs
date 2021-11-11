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
    private NavMeshAgent _navMeshAgent;
    

    void Start()
    {
        _healthComponent = GetComponent<HealthComponent>();
        _animator = GetComponent<Animator>();
        _sightPerceptionComp = GetComponent<SightPerceptionComp>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _sightPerceptionComp.onPerceptionUpdated += UpdatedPerception;
        
        if (_healthComponent)
        {
            _healthComponent._onDamageTaken += TookDamage;
            _healthComponent._onHitPointDepleted += Dead;
        }
    }

    private void UpdatedPerception(PerceptionStimuli stimuli,bool successfullysensed)
    {
        float SpeedVal = _navMeshAgent.acceleration / _navMeshAgent.speed;
        if (successfullysensed)
        {
            _navMeshAgent.SetDestination(stimuli.gameObject.transform.position);
            Debug.Log(stimuli.gameObject.transform.position);
            _animator.SetFloat("Speed", SpeedVal);
        }
        else
        {
            _animator.SetFloat("Speed",Mathf.Lerp(SpeedVal, 0, 1f));
        }
    }


    private void Dead()
    {
        //play dead anim
        Debug.Log("I am dead");
        _animator.SetTrigger("Dead");
    }

    private void TookDamage(int newamt, int oldamt)
    {
        Debug.Log($"Took: {newamt - oldamt} of Damage");
    }

    public void DeathAnimationFinished()
    {
        Invoke("DestroySelf",1);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
