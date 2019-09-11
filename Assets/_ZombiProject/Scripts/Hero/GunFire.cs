using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour {

    public int damage = 10;
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
    public GameObject reloadGO;
    bool isReloading = false;
    
    
    private float nextTimeToFire = 0f;    
    

	void FixedUpdate ()
    {
        if (Input.GetKeyDown(KeyCode.R) && bullets < 30)
        {
            if (!isReloading)
            {
                StartCoroutine("ReloadWeapon");
            }
        }
        if (clips >= 0)
        {
            // gameObject.GetComponentInParent<PlayerStats>().AmmoConsuption(clips);

            if (bullets > 0 && !isReloading) 
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
                if (!isReloading)
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
    public IEnumerator ReloadWeapon()
    {
        isReloading = true;
        reloadGO.GetComponent<Animator>().SetBool("reload", true);
 //       Debug.Log("reload coroutine started ");
        //       gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("WeaponReload");
        yield return new WaitForSeconds(2f); // reload time
        reloadGO.GetComponent<Animator>().SetBool("reload", false);
        isReloading = false;
        stopReload();
        yield break;
    }

    public void stopReload()
    {
        if (clips > 0 || bullets > 0)
        {
//            Debug.Log("reload coroutine stopped");
            //   gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Idle");
            bullets = 30;
            clips = clips - 1;
            //            Debug.Log("clips - 1 = " + clips);
            gameObject.GetComponentInParent<PlayerStats>().AmmoConsuption(bullets, clips);
 //           Debug.Log("reload finished, bullets " + bullets + " clips " + clips);
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
            EnemyTakeDamage target = rHit.transform.GetComponent<EnemyTakeDamage>();
            
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

    public void PickUpWeaponUpgrade (int x)
    {
        damage = damage + x;
    }
}
