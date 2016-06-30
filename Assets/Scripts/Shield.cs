using System;
using UnityEngine;

public class Shield : ScriptableObject
{

    public float shFireRate = 2;
    public float shDuration = 1;
    public float shLastFire = 0;

    public Transform origin;
    public GameObject PrefabShield;

    
    public void Fire()
    {
        var shieldReady = shLastFire + shFireRate;

        if (shieldReady >= Time.time)
            return;

        Instantiate(PrefabShield, origin.position, origin.rotation);
        shLastFire = Time.time;  

    }

    public void checkShieldDestroy()
    {
        if (shLastFire - shDuration > shLastFire)
        {
            Destroy(this);
        }
    }

    internal void Init(Transform playerTransform, GameObject shield)
    {
        this.origin = playerTransform;
        this.PrefabShield = shield;
        shLastFire = Time.time;
    }
}
