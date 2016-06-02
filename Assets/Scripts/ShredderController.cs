using UnityEngine;
using System.Collections;

public class ShredderController : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }

}
