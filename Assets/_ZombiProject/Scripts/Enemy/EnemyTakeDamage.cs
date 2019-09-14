using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// when zombi recieve damage
public class EnemyTakeDamage : MonoBehaviour {

    [SerializeField]
    public float health = 100;
    [SerializeField]
    GameObject hitPlayerTrigger;


    private void Start()
    {
        
    }

    public void TakeDamage(float ammount)
    {
        health -= ammount;
        if (health <= 0f)
        {
            gameObject.GetComponent<EnemyMeleeHit>().EnemyDeathAnim();
            StartCoroutine(KillZombi());
        }
    }

    IEnumerator KillZombi () // zombie death
    {
        Destroy(hitPlayerTrigger);

        BoxCollider enemyBoxCol = GetComponent<BoxCollider>();
        enemyBoxCol.enabled = false;

        Rigidbody zombieRB = gameObject.GetComponent<Rigidbody>();
        Destroy(zombieRB);

        GetComponent<EnemyMoves>().enabled = false;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
        
    }
}
