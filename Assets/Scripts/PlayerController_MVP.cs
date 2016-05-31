using UnityEngine;
using System.Collections;

public class PlayerController_MVP : MonoBehaviour
{

    public float speed;
    public float tilt;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButton("P1_Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            //GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("P1_Horizontal");
        float moveVertical = Input.GetAxis("P1_Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;

        var boundary = new Boundary();

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
    }
}

    public class Boundary
    {
        public float xMin, xMax, zMin, zMax;
        Vector3 origin = Camera.main.ViewportToWorldPoint(new Vector3(0.05f, 0.05f, 0));
        Vector3 extent = Camera.main.ViewportToWorldPoint(new Vector3(0.95f, 0.6f, 0));

    /* - camera clamp from unity forums - try to incorporate?
         void Update() {
         Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
         pos.x = Mathf.Clamp01(pos.x);
         pos.y = Mathf.Clamp01(pos.y);
         transform.position = Camera.main.ViewportToWorldPoint(pos);
     }
    */
    void CalculateBoundary()
        {
        xMin = origin.x;
        xMax = extent.x;
        zMin = origin.z;
        zMax = extent.z;
        }
               
    }
 