using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour {

    [SerializeField]
    float RotationSpeed = 10f;

	void Update ()
    {
        transform.Rotate(Vector3.up * RotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hero")
        {
            int x = other.GetComponent<HeroStats>().heroHealthF;
            Debug.Log("hero health on pick up " + x);
            if (x < 125)
            {
                x = x + 50;
                if (x > 125)
                {
                    x = 125;
                    other.GetComponent<HeroStats>().HeroHitted(x, 0); // health pack picked
                    Debug.Log("hero health on pick up set x to 125 " + x);
                    Destroy(gameObject);
                }
                if (x <= 125)
                {
               //     other.GetComponent<HeroStats>().HeroHitted(x, 0); // health pack picked
               //     Debug.Log("hero health on pick up x < 125 " + x);
                    Destroy(gameObject);
                }
            }
        }    
    }
}
