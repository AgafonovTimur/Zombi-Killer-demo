using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAmmo : MonoBehaviour {

    [SerializeField]
    float RotationSpeed = 2f;
    [SerializeField]
    int clipsToAdd = 7;

	void Update ()
    {
        transform.Rotate(Vector3.up * RotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            int x = other.GetComponent<GunFire>().bullets; 
            int y = other.GetComponent<PlayerStats>().clipsAmmount;

            if (y < 10) // ammo pack picked
            {
                y = y + clipsToAdd;

                if (y > 10)
                {
                    y = 10;
                    other.GetComponentInChildren<PlayerStats>().AmmoConsuption(x, y); // ammo pack picked
                    Destroy(gameObject);
                }
                if (y <= 10)
                {
                    other.GetComponentInChildren<PlayerStats>().AmmoConsuption(x, y); // ammo pack picked
                    Destroy(gameObject);
                }
            }
        }    
    }
}
