using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public Camera FPSCamera;
    public ParticleSystem gunPSFX;
    public ParticleSystem gunPSSparks;
    public GameObject bloodAfterHitEffect;
    public float fireRate = 15f;
    public GameObject bulletPrefab;
    public Transform bulletEmitter;
    
    


    private float nextTimeToFire = 0f;    
    

	void Update ()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
           // Debug.Log(nextTimeToFire + " " + fireRate);
            ShootABullet();
        }
    }

    public void ShootABullet()
    {
        
        gunPSFX.Emit(1);
        gunPSSparks.Emit(1);
        RaycastHit rHit;
        if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out rHit, range))
        {
        //    Debug.Log(rHit.transform.name);
            TargetHit target = rHit.transform.GetComponent<TargetHit>();
            
            GameObject bInst = Instantiate(bulletPrefab, bulletEmitter.position, bulletEmitter.rotation) as GameObject;
            bInst.GetComponent<Bullet>().bulletPos(rHit.point);
         //   Debug.Log("rayhit "+ rHit.transform.position);
           
            
            Debug.DrawRay(FPSCamera.transform.position, FPSCamera.transform.forward, Color.green);

            if (target != null && target.tag == "Enemy" )
            {
                target.TakeDamage(damage);
                Instantiate(bloodAfterHitEffect, rHit.point, Quaternion.LookRotation(rHit.normal));
            }
            
        }
    }
}
