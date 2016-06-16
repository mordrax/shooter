
using System;
using UnityEngine;

namespace Assets.Scripts
{
    class Weapon : MonoBehaviour
    {
        public float FireRate = 2;

        float LastFire;
        public Transform origin;
        public GameObject bullet;

        public Weapon(Transform playerTransform, GameObject bullet)
        {
            this.origin= playerTransform;
            this.bullet = bullet;
            LastFire = Time.time;
        }

        public void Fire()
        {
            Console.WriteLine(string.Format("LastFire({0}) Time({1})", LastFire, Time.time));
            if (LastFire < Time.time + FireRate)
                return;
            
            Instantiate(bullet, origin.position, origin.rotation);
            LastFire = Time.time;
        }
    }
}
