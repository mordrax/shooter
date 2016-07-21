using System;
using UnityEngine;

public class Shield : ScriptableObject
{

    public float shFireRate;
    public float shDuration = 3;
    public float shLastFire;
    

    public Transform origin;
    public GameObject PrefabShield;
    private UnityEngine.Object shield;
    private GameObject parent;

    void Start()
    {
        
    }

    public void Fire()
    {
        var shieldReady = shLastFire + shFireRate;

        if (shieldReady >= Time.time)
            return;

        shield = Instantiate(PrefabShield, origin.position, origin.rotation);
        shLastFire = Time.time;

    }

    public void checkShieldDestroy(Transform player)
    {
        if (shield != null)
        {
            shield.transform.parent = player;
        }

        var timeSinceLastFire = Time.time - shLastFire;
        if (timeSinceLastFire > shDuration) 
        {
            Destroy(shield);
        }
    }

    internal void Init(Transform parent, GameObject shield)
    {
        this.origin = parent;
        this.PrefabShield = shield;
        
        shLastFire = Time.time;
    }
}
