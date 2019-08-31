using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

    public Vector3 aimForBullet;
    [SerializeField]
    GameObject FX;
    [SerializeField]
    GameObject spark;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    GameObject bulletEmitter;
    [SerializeField]
    float speed = 1.0f;
    

    void Update () {
        RaycastHit rayHit;

        //if (Physics.Raycast(transform.position, transform.forward,out rayHit, 100));
        //{
        //    aimForBullet = rayHit.transform.position;
        //    Debug.Log(rayHit.transform.position);
        //}
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out rayHit, 100)) ;
            {
                aimForBullet = rayHit.transform.position;
                
                Debug.Log("rayhit " + aimForBullet + rayHit.collider.name);
            }
           // totalSpeed = aimForBullet * speed * Time.deltaTime;
            // emit fx on weapon
            FX.GetComponent<ParticleSystem>().Emit(1);

            spark.GetComponent<ParticleSystem>().Emit(1);
            
            GameObject go = Instantiate(bulletPrefab, bulletEmitter.transform.position,bulletEmitter.transform.rotation) as GameObject;
            PlayerPrefs.SetFloat("aim1", aimForBullet.x);
            PlayerPrefs.SetFloat("aim2", aimForBullet.y);
            PlayerPrefs.SetFloat("aim3", aimForBullet.z);
            //Bullet.AimCoordinates(aimForBullet);
           // bulletPrefab.transform.Translate(aimForBullet *speed* Time.deltaTime);
            //Instantiate(bulletPrefab, bulletEmitter.transform.position,
            //    bulletEmitter.transform.rotation);


        }

    }
}
