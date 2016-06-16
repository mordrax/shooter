using UnityEngine;

namespace Assets.Scripts
{
    public class Engine
    {
        public static float THRUST_DURATION = 2;
        public static float COOLDOWN = 4;
        public static float THRUST_POWER = 5;

        public float LastThrust;
        public bool isThrusting;
        public bool isCoolingDown;

        public void Update()
        {
            isThrusting = ((Time.time - LastThrust) < Engine.THRUST_DURATION);

            isCoolingDown = ((Time.time - LastThrust) < Engine.COOLDOWN);
        }
    }

}
