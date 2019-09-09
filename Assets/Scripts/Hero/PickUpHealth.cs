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
            //    Debug.Log("player health on pick up " + x);
            if (x < 125) // health pack picked
            {
                x = x + 50;
         //       Debug.Log("x+50 = " + x);
                if (x > 125)
                {
                    x = 125;
                    other.GetComponent<PlayerStats>().PlayerHealed(x, 0); // health pack picked
                                                                          //        Debug.Log("player health after pick up set x to 125 " + x);
                    Destroy(gameObject);
                }
                if (x <= 125)
                {
                    other.GetComponent<PlayerStats>().PlayerHealed(x, 0); // health pack picked
                                                                          //         Debug.Log("player health on pick up x < 125 " + x);
                    Destroy(gameObject);
                }
            }
            if (x >= 125) // health pack cant be picked
            {  
         //       Debug.Log("cant pick health pack");
            }
        }    
    }
}
