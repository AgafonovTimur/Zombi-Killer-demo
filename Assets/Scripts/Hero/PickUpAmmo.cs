using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAmmo : MonoBehaviour {

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
            int x = other.GetComponentInChildren<GunFire>().bullets;
            int y = other.GetComponent<PlayerStats>().clipsAmmount;
        //    int x = other.GetComponentInChildren<GunFire>().clips;
            Debug.Log("clips on pick up " + x + " "  + y);
            if (y >= 10) // ammo pack cant be picked
            {
                Debug.Log("cant pick ammo pack");
            }
            if (y < 10) // health pack picked
            {
                y = y + 7;
                Debug.Log("y+7 = " + y + " " + x);
                if (y > 10)
                {
                    y = 10;
                    other.GetComponentInChildren<PlayerStats>().AmmoConsuption(x, y); // ammo pack picked
                    Debug.Log("clips to 10 " + x + " " + y);
                    Destroy(gameObject);
                }
                if (y <= 10)
                {
                    other.GetComponentInChildren<PlayerStats>().AmmoConsuption(x, y); // ammo pack picked
                    Debug.Log("clips <= 10 " + y);
                    Destroy(gameObject);
                }
            }
        }    
    }
}
