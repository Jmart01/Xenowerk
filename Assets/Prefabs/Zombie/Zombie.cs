using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class Zombie : MonoBehaviour
{
    private HealthComponent _healthComponent;

    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _healthComponent = GetComponent<HealthComponent>();
        _animator = GetComponent<Animator>();
        
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
