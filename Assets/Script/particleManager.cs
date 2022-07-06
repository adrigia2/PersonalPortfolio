using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleManager : MonoBehaviour
{
    ParticleSystem system;
    void Start()
    {
        system=GetComponent<ParticleSystem>();

        transform.parent.gameObject.GetComponent<Bullet>().onHitSurface += ParticleManager_onHitSurface;
    }

    private void ParticleManager_onHitSurface()
    {
         system.Play();
    }

    private void OnDestroy()
    {
        transform.parent.gameObject.GetComponent<Bullet>().onHitSurface -= ParticleManager_onHitSurface;

    }
}
