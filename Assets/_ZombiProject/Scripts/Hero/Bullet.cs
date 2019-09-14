using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bullet : MonoBehaviour
{
    [SerializeField]
    float bulletLifeTime = 1f;
    public float bulletSpeed = 20f;
    public Rigidbody rb;
    public Vector3 bulletTarget ;
    Vector3 oneBulletShoot;

    private void Start()
    {
        Destroy(gameObject, bulletLifeTime);
        
    }
    void Update()
    {
        float step = bulletSpeed * Time.deltaTime;

        if (bulletTarget != null)
        {
            oneBulletShoot = Vector3.MoveTowards(transform.position, bulletTarget, step);
            transform.position = oneBulletShoot;
        }
    }
    public void bulletPos(Vector3 target)
    {
        bulletTarget = target;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

}
