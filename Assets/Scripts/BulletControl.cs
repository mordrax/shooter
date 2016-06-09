using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {

    public float bulletSpeed;


	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
        GetComponent<Rigidbody>().transform.Rotate(new Vector3(180, 90, 90));
    }
	
	// Update is called once per frame
	void Update ()
    {
       // GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
    }
}
