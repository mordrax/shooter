using System;
using System.Collections;
using UnityEngine;

public class Shield : MonoBehaviour {

    public float shFireRate = 2;
    public float shDuration = 1;

    float shLastFire;
    public Transform origin;
    public GameObject shield;

    public Shield(Transform playerTransform, GameObject shield)
    {
        this.origin = playerTransform;
        this.shield = shield;
        shLastFire = Time.time;
    }

    public void Fire()
    {
        Console.WriteLine(string.Format("LastFire({0}) Time({1})", shLastFire, Time.time));
        if (shLastFire < Time.time + shFireRate)
            return;

        Instantiate(shield, origin.position, origin.rotation);
        shLastFire = Time.time;

        while (shLastFire - shDuration < shLastFire)
        {
        }
        Destroy(shield);
        ;  
    }
}
