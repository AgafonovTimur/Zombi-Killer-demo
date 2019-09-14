using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// change weapon color and add weapon damage

public class WeaponUpgrade : MonoBehaviour {

    [SerializeField]
    Color weaponColor;
    [SerializeField]
    int addWeaponDamage;

	
	void Start () {
        gameObject.GetComponent<Renderer>().material.color = weaponColor; // ("red",Color.red);
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            other.GetComponent<GunFire>().PickUpWeaponUpgrade(addWeaponDamage);
            Destroy(gameObject);
        }
    }
}
