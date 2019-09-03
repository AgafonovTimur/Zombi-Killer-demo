using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    [SerializeField]
    int bullets = 30;
    int oneBullet = 1;
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
        if (bullets > 0)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                bullets = bullets - 1;
                // Debug.Log(nextTimeToFire + " " + fireRate);
                Debug.Log("now "+bullets);
                gameObject.GetComponentInParent<HeroStats>().AmmoConsuption(bullets);// shooting
                ShootABullet();
            }
        }
        else if (bullets <= 0)
        {
            if (!coroutineIsRunnig)
            {
                StartCoroutine("ReloadWeapon");
            }
            Debug.Log("reload");
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
        Debug.Log("reload coroutine stopped");
     //   gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Idle");
        bullets = 30;
        gameObject.GetComponentInParent<HeroStats>().AmmoConsuption(bullets);
        Debug.Log("reload stopped, bullets " + bullets);
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
