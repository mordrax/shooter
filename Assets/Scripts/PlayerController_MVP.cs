using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts;

public class PlayerController_MVP : MonoBehaviour
{

    public float speed;
    public float tilt;
    public float P1_firerate_W1;
    public float P1_firerate_W2;
    
    public float P1_shieldrate;
    public float P1_shipmass;
    public Transform playerTransform;
    public GameObject bullet;
    public GameObject self;
    float P1_nextfire_W1;
    float P1_nextfire_W2;
    float P1_Wswitch;

    private int currentPrimaryWeapon = 0;
    private int currentSecondaryWeapon = 1;

    Engine engine;
    Dictionary<int, Weapon> weapons;
    

    // Use this for initialization
    void Start()
    {
        engine = new Engine();
        weapons = new Dictionary<int, Weapon>();
        
        weapons.Add(0, new Weapon(playerTransform, bullet));
        weapons.Add(1, new Weapon(playerTransform, bullet, new WellOiledRecoilPart())); 
    }

    void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        engine.Update();
        P1_Move();
        CalculateBoundary();
        checkFire_W1();
        checkFire_W2();
        checkShield();
        checkSwitch();
    }

    void P1_Move()
    {
        float moveHorizontal = Input.GetAxis("P1_Horizontal");
        float moveVertical = Input.GetAxis("P1_Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (engine.isThrusting)
        {
            GetComponent<Rigidbody>().velocity = (movement * speed * Engine.THRUST_POWER)/ P1_shipmass;
        } else
        {
            GetComponent<Rigidbody>().velocity = (movement * speed)/P1_shipmass;
        }

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
    }

    void CalculateBoundary()
    {
        Vector3 player1 = GameObject.FindGameObjectWithTag("Player").transform.position;
        float distance = Camera.main.transform.position.y - player1.y;

        Vector3 origin = Camera.main.ViewportToWorldPoint(new Vector3(0.05f, 0.08f, distance));
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

    void checkFire_W1()
    {
        if (Input.GetButton("P1_Fire1"))
            weapons[this.currentPrimaryWeapon].Fire();
    }

    void checkFire_W2()
    {
        if (Input.GetButton("P1_Fire2"))
            weapons[this.currentSecondaryWeapon].Fire();
    }

    void checkShield()
    {

    }
    void checkEngine()
    {

    }
    void checkSwitch()
    {
    }

}
 