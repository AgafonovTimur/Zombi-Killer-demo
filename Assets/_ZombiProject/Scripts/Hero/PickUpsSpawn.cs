using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpsSpawn : MonoBehaviour {

    [SerializeField]
    GameObject PickUp;



    void Start () {
        Instantiate(PickUp, transform.position, transform.rotation);
    }
	
	
	void Update () {
        
    }
}


//private bool enterCollider = true;

//private void OnTriggerEnter(Collider other)
//{
//    if (other.gameObject.tag == ")
//    {
//        //   transform.gameObject.SetActive(true);
//        enemySpawn();
//        Destroy(gameObject);
//    }
//}

//private void enemySpawn()
//{
//    Instantiate(ZombiPrefab, transform.position, transform.rotation);
//}