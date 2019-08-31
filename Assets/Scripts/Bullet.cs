using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Crosshair))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    float speed = 1.0f;
    [SerializeField]
    float bulletLifeTime = 5.0f;
    [SerializeField]
    GameObject bulletBlood;
    [SerializeField]
    GameObject character;
    Vector3 aimPoint;
    
    
    private void Start()
    {
        
        Destroy(gameObject, bulletLifeTime);
        Debug.Log("bullet destroyed");
    }

    
    void Update()
    {
        //aimPoint = new Vector3(PlayerPrefs.GetFloat("aim1"), PlayerPrefs.GetFloat("aim2"), PlayerPrefs.GetFloat("aim3"));
        //transform.Translate (aimPoint * speed * Time.deltaTime);
        //transform.position = Vector3.Lerp(transform.position, aimPoint, speed * Time.deltaTime);
        
        aimPoint = new Vector3(PlayerPrefs.GetFloat("aim1"), PlayerPrefs.GetFloat("aim2"), PlayerPrefs.GetFloat("aim3"));
        transform.Translate( aimPoint * speed * Time.deltaTime);
        Debug.Log("my res " + aimPoint);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            print("bullet destroyed on enemy");
            
            Instantiate(bulletBlood,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }


}
