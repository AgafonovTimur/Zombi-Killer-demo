using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftActivation : MonoBehaviour {

    [SerializeField]
    GameObject lift;
	
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        lift.GetComponent<BoxCollider>().enabled = true;
    }
}
