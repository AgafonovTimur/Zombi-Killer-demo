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
        int curBullets = gameObject.GetComponentInParent<PlayerStats>().bulletAmmount;
        int curClips = gameObject.GetComponentInParent<PlayerStats>().clipsAmmount;

        if (Input.GetKeyDown(KeyCode.R) && bullets < 30)
        {
            if (!isReloading)
            {
                StartCoroutine("ReloadWeapon");
            }
        }
        if (clips >= 0)
        {
            if (bullets > 0 && !isReloading) 
            {
                if (Input.GetButton("Fire1") && Time.fixedTime >= nextTimeToFire)
                {
                    if (bullets != curBullets)
                    {
                        curBullets = bullets;
                    }
                    if(clips != curClips)
                    {
                        clips = curClips;
                    }
                    nextTimeToFire = Time.fixedTime + 1f / fireRate;
                    bullets = bullets - 1;
                    gameObject.GetComponentInParent<PlayerStats>().AmmoConsuption(bullets,clips); // while shooting
                    ShootABullet();
                }
            }
            else if (bullets <= 0 && clips > 0 )
            {
                if (!isReloading)
                {
                    StartCoroutine("ReloadWeapon");
                }
            }
        }
        if (clips <= 0 && bullets <= 0)
        {
            gameObject.GetComponentInParent<PlayerStats>().AmmoConsuption(bullets, clips);  // out of ammo
        }
    }
   
    // add clips counter and out of ammo Label
    public IEnumerator ReloadWeapon()
    {
        Animator anim = reloadGO.GetComponent<Animator>();
        isReloading = true;
        anim.SetBool("reload", true);
        yield return new WaitForSeconds(2f); // reload time
        anim.SetBool("reload", false);
        isReloading = false;
        stopReload();
        yield break;
    }

    public void stopReload()
    {
        if (clips > 0 || bullets > 0)
        {
            bullets = 30;
            clips = clips - 1;
            gameObject.GetComponentInParent<PlayerStats>().AmmoConsuption(bullets, clips);
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
            EnemyTakeDamage target = rHit.transform.GetComponent<EnemyTakeDamage>();
            
            GameObject bInst = Instantiate(bulletPrefab, bulletEmitter.position, bulletEmitter.rotation) as GameObject;
            bInst.GetComponent<Bullet>().bulletPos(rHit.point);

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
