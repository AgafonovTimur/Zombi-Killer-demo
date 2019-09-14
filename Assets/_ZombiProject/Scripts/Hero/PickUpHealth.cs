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
            int x = other.GetComponent<PlayerStats>().playerHealthF;
            if (x < 125) // health pack picked
            {
                x = x + 50;

                if (x > 125)
                {
                    x = 125;
                    other.GetComponent<PlayerStats>().PlayerHealed(x, 0); // health pack picked
                    Destroy(gameObject);
                }
                if (x <= 125)
                {
                    other.GetComponent<PlayerStats>().PlayerHealed(x, 0); // health pack picked
                    Destroy(gameObject);
                }
            }
        }    
    }
}
