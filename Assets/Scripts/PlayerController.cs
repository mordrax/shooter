using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;

    void CameraBoundary()
    {
        Vector3 minXZ = Camera.main.ViewportToScreenPoint(new Vector3(0f, 0.2f, 0f));
        //restrict player to bottom 60% of z-axis but whole range of x-axis (within camera perspective)
        Vector3 maxXZ = Camera.main.ViewportToScreenPoint(new Vector3(1f, 0.2f, 0.6f));
    }

    public class PlayerController : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        public float speed;
        public Boundary boundary;
        public float tilt;

        //main game loop
        void FixedUpdate()
        {
            PlayerControls();
        }


        //handles player movement, speed and location (clamped to camera viewpoint)
        void PlayerControls()
        {
            //player controls
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            //player speed
            GetComponent<Rigidbody>().velocity = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed;

            //player transform
            GetComponent<Rigidbody>().position = new Vector3(
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
                1.0f,
                Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
                );

            GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
