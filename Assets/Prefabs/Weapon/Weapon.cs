using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private AnimationClip ShootingAnimation;
    [SerializeField] private ParticleSystem BulletEmitter;
    [SerializeField] private int BulletDamage = 1;
    public void Fire()
    {
        BulletEmitter.Emit(BulletEmitter.emission.GetBurst(0).maxCount);
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public AnimationClip GetFireAnimation()
    {
        return ShootingAnimation;
    }

    public int GetBulletDmg()
    {
        return BulletDamage;
    }
}
