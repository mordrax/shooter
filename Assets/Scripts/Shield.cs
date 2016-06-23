using System;
using UnityEngine;

public class Shield : ScriptableObject
{

    public float shFireRate = 2;
    public float shDuration = 1;

    float shLastFire;
    public Transform origin;
    public GameObject shield;

    
    public void Fire()
    {
        Debug.LogFormat("LastFire({0}) Time({1})", shLastFire, Time.time);
        var shieldReady = shLastFire + shFireRate;

        if (shieldReady >= Time.time)
            return;

        Instantiate(shield, origin.position, origin.rotation);
        shLastFire = Time.time;


        while (shLastFire - shDuration < shLastFire)
        {
            // this
        }

        Destroy(shield);
    }

    internal void Init(Transform playerTransform, GameObject shield)
    {
        this.origin = playerTransform;
        this.shield = shield;
        shLastFire = Time.time;
    }
}
