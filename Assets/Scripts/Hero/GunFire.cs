using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    [SerializeField]
    public int bullets = 30;
    [SerializeField]
    public int clips = 10;
    public Camera FPSCamera;
    public ParticleSystem gunPSFX;
    public ParticleSystem gunPSSparks;
    public GameObject bloodAfterHitEffect;
    public GameObject bulletPrefab;
    public Transform bulletEmitter;
    bool coroutineIsRunnig = false;
    
    
    private float nextTimeToFire = 0f;    
    

	void FixedUpdate ()
    {
        if (clips >= 0)
        {
            // gameObject.GetComponentInParent<PlayerStats>().AmmoConsuption(clips);

            if (bullets > 0)
            {
                if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
                {
                    if (bullets != gameObject.GetComponentInParent<PlayerStats>().bulletAmmount)
                    {
                        gameObject.GetComponentInParent<PlayerStats>().bulletAmmount = bullets;
                    }
                    if(clips != gameObject.GetComponentInParent<PlayerStats>().clipsAmmount)
                    {
                        clips = gameObject.GetComponentInParent<PlayerStats>().clipsAmmount;
                    }
                    nextTimeToFire = Time.time + 1f / fireRate;
                    bullets = bullets - 1;
                    // Debug.Log(nextTimeToFire + " " + fireRate);
  //                  Debug.Log("now "+ bullets + " " +clips);
                    gameObject.GetComponentInParent<PlayerStats>().AmmoConsuption(bullets,clips);// shooting
                    ShootABullet();
                }
            }
            else if (bullets <= 0 && clips > 0 )
            {
                if (!coroutineIsRunnig)
                {
                    StartCoroutine("ReloadWeapon");
                }
          //      Debug.Log("reloading++ add animation");
            }
        }
        if (clips <= 0 && bullets <= 0)
        {
            gameObject.GetComponentInParent<PlayerStats>().AmmoConsuption(bullets, clips);// out of ammo
            Debug.Log("out of ammo bullets " + bullets + " " + clips);
        }
    }
   
    // add clips counter and out of ammo Label
    public IEnumerator ReloadWeapon( )
    {
        coroutineIsRunnig = true;
        // gameObject.transform.GetChild(0).GetComponent<Animation>().Play("WeaponReload");
        yield return new WaitForSeconds(2.5f); // reload time
        Debug.Log("reload coroutine started ");
        coroutineIsRunnig = false;
        stopReload();
    }

    public void stopReload()
    {
        if (clips > 0 || bullets > 0)
        {
            Debug.Log("reload coroutine stopped");
            //   gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Idle");
            bullets = 30;
            clips = clips - 1;
            Debug.Log("clips - 1 = " + clips);
            gameObject.GetComponentInParent<PlayerStats>().AmmoConsuption(bullets, clips);
            Debug.Log("reload stopped, bullets " + bullets + " clips " + clips);
        }
        if (clips < 0 && bullets < 0)
        {
            Debug.Log("out of ammo (reload func)");
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
            ZombiTakeDamage target = rHit.transform.GetComponent<ZombiTakeDamage>();
            
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
