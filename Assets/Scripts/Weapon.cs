
using System;
using UnityEngine;

namespace Assets.Scripts
{
    class Weapon : ScriptableObject
    {
        public float Cooldown = 2;

        float LastFire;
        public Transform origin;
        public GameObject bullet;

        public void Fire()
        {
            var weaponReadyTime = LastFire + Cooldown;
            if (weaponReadyTime >= Time.time)
                return;
            
            Instantiate(bullet, origin.position, origin.rotation);
            LastFire = Time.time;
        }

        internal void Init(Transform playerTransform, GameObject bullet)
        {
            this.origin = playerTransform;
            this.bullet = bullet;
            LastFire = Time.time;
        }
    }
}
