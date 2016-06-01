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
        P1_Move();
        CalculateBoundary();
    }

    void P1_Move()
    {
        float moveHorizontal = Input.GetAxis("P1_Horizontal");
        float moveVertical = Input.GetAxis("P1_Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
    }

    void CalculateBoundary()
    {
        Vector3 player1 = GameObject.FindGameObjectWithTag("Player").transform.position;
        float distance = Camera.main.transform.position.y - player1.y;

        Vector3 origin = Camera.main.ViewportToWorldPoint(new Vector3(0.05f, 0.05f, distance));
        Vector3 extent = Camera.main.ViewportToWorldPoint(new Vector3(0.95f, 0.6f, distance));
        float xMin = origin.x;
        float xMax = extent.x;
        float zMin = origin.z;
        float zMax = extent.z;

        GetComponent<Rigidbody>().position = new Vector3
        (
        Mathf.Clamp(GetComponent<Rigidbody>().position.x, xMin, xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, zMin, zMax)
        );
    }
}
 