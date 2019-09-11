using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour {

    [SerializeField]
    Color weaponColor;
    [SerializeField]
    int newWeaponDamage;

	
	void Start () {
        gameObject.GetComponent<Renderer>().material.color = weaponColor; // ("red",Color.red);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            other.GetComponent<GunFire>().PickUpWeaponUpgrade(newWeaponDamage);
            Destroy(gameObject);
        }
    }
}
