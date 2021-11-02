using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private ParticleSystem BulletEmitter;
    public void Fire()
    {
        BulletEmitter.Emit(BulletEmitter.emission.GetBurst(0).maxCount);
    }
}
