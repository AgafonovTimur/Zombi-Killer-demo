using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    [SerializeField]
    GameObject ZombiPrefab;
    private bool enterCollider = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hero")
        {
         //   transform.gameObject.SetActive(true);
            enemySpawn();
            Destroy(gameObject);
        }
    }
    
    private void enemySpawn()
    {
        Instantiate(ZombiPrefab, transform.position, transform.rotation);
    } 
}
