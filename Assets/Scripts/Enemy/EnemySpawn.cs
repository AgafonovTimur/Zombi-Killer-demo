using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    [SerializeField]
    GameObject ZombiPrefab;
    private bool enterCollider = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //   transform.gameObject.SetActive(true);
            ZombiSpawn();
            Destroy(gameObject);
        }
    }
    
    private void ZombiSpawn()
    {
        Instantiate(ZombiPrefab, transform.position, transform.rotation);
    } 
}
