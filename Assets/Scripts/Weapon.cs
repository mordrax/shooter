
using UnityEngine;

namespace Assets.Scripts
{
    class Weapon : MonoBehaviour
    {
        float LastFire;
        public Transform origin;
        public GameObject bullet;
        public float Cooldown { get { return 2f; } }

        public Weapon(Transform playerTransform, GameObject bullet)
        {
            origin = playerTransform;
            this.bullet = bullet;
            LastFire = Time.time;
        }

        public void Fire()
        {
            Debug.Log(string.Format("LastFire({0}) Time({1})", LastFire, Time.time));
            if (LastFire + Cooldown >= Time.time)
                return;

            Instantiate(bullet, origin.position, origin.rotation);
            LastFire = Time.time;
        }

    }

}
