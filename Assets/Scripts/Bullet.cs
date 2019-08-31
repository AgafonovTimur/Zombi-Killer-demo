using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    float speed = 1.0f;
    [SerializeField]
    float bulletLifeTime = 5.0f;
    ParticleSystem bulletPS;
    
    // git test push
    private void Start()
    {
        Destroy(gameObject, bulletLifeTime);
        Debug.Log("bullet destroyed");
    }

    void Update()
    {
        transform.Translate (Vector3.forward * speed * Time.deltaTime);
        
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            print("bullet destroyed on enemy");
            bulletPS.GetComponent<ParticleSystem>().Emit(1);

            Destroy(gameObject);
        }
    }
}
