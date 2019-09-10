using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bullet : MonoBehaviour
{
    [SerializeField]
    float bulletLifeTime;
    public float bulletSpeed = 20f;
    public Rigidbody rb;
    public Vector3 bulletTarget ;

    private void Start()
    {
        Destroy(gameObject, bulletLifeTime);
        
    }
    void Update()
    {
        float step = bulletSpeed * Time.deltaTime;

        if (bulletTarget != null)
        {

            transform.position = Vector3.MoveTowards(transform.position, bulletTarget, step);
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
