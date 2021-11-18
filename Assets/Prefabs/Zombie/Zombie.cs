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
    private AIController _aiController;
    private int UpperBodyIndex;
    [SerializeField] private GameObject HitboxToSpawn;
    [SerializeField] private GameObject HitboxToSpawnPoint;
    


    void Start()
    {
        _healthComponent = GetComponent<HealthComponent>();
        _animator = GetComponent<Animator>();
        _sightPerceptionComp = GetComponent<SightPerceptionComp>();
        UpperBodyIndex = _animator.GetLayerIndex("UpperBody");

        if (_healthComponent)
        {
            _healthComponent._onDamageTaken += TookDamage;
            _healthComponent._onHitPointDepleted += Dead;
        }

        if (_aiController)
        {
            _aiController._attackTarget += Attack;
        }
    }

    private void Attack()
    {
        _animator.SetLayerWeight(UpperBodyIndex,1);
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

    public void ResetLayerWeight()
    {
        _animator.SetLayerWeight(UpperBodyIndex,0);
    }

    void SpawnHitBox()
    {
        Instantiate(HitboxToSpawn, HitboxToSpawnPoint.transform);
    }
}