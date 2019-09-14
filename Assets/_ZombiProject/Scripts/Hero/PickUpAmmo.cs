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

            if (y < 10) // health pack picked
            {
                y = y + 7;

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
