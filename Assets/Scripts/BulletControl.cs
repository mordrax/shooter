using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {

    public float bulletSpeed;


	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
    }
	
	// Update is called once per frame
	void Update ()
    {
       // GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
    }
}
