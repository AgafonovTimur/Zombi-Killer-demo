using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour {

    [SerializeField]
    GameObject spark;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    GameObject bulletEmitter;


    void Update () {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            GetComponent<ParticleSystem>().Emit(1);
            spark.GetComponent<ParticleSystem>().Emit(1);
            Instantiate(bulletPrefab, bulletEmitter.transform.position,
                bulletEmitter.transform.rotation);
        }
	}
}
