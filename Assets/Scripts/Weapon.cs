
using System;
using UnityEngine;

namespace Assets.Scripts
{
    class Weapon : MonoBehaviour
    {
        public RecoilPart Recoil;

        float LastFire;
        public Transform origin;
        public GameObject bullet;

        public Weapon(Transform playerTransform, GameObject bullet, RecoilPart recoil = null)
        {
            origin= playerTransform;
            this.bullet = bullet;
            LastFire = Time.time;

            if (recoil == null)
                recoil = new RecoilPart();
            Recoil = recoil;
        }

        public void Fire()
        {
            Debug.Log(string.Format("LastFire({0}) Time({1})", LastFire, Time.time));
            if (LastFire + Recoil.Cooldown >= Time.time)
                return;
            
            Instantiate(bullet, origin.position, origin.rotation);
            LastFire = Time.time;
        }

        public void UpgradeRecoil(RecoilPart newPart)
        {
            Recoil = newPart;
        }
    }


    class RecoilPart
    {
        public virtual float Cooldown { get { return 2f; } }
    }

    class WellOiledRecoilPart : RecoilPart
    {
        public override float Cooldown { get { return 0.2f; } }
    }

    class VeryVeryWellOiledRecoilPart : RecoilPart
    {
        public override float Cooldown { get { return 0f; } }
    }

    class Scope
    {
        public int Accuracy = 100;
    }
}
