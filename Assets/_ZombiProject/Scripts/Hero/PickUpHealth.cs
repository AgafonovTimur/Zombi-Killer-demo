using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHealth : MonoBehaviour {

    [SerializeField]
    float RotationSpeed = 2f;

	void Update ()
    {
        transform.Rotate(Vector3.up * RotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            int x = other.GetComponent<PlayerStats>().playerHealth;

            if (x < 125)
            {
                other.GetComponent<PlayerStats>().PlayerHealthChanges(50, 0);
                Destroy(gameObject);
            }
        }    
    }
}
