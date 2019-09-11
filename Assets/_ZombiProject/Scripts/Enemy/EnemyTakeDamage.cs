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
    
    public void TakeDamage(float ammount)
    {
        health -= ammount;
        if (health <= 0f)
        {
            gameObject.GetComponent<EnemyMeleeHit>().EnemyDeathAnim();
            StartCoroutine(KillZombi());
 //           Debug.Log("zombi killed");
        }
    }

    IEnumerator KillZombi () // zombie death
    {
        hitPlayerTrigger.GetComponent<BoxCollider>().enabled = false;
        //GetComponent<BoxCollider>().enabled = false;
        GetComponent<EnemyMoves>().enabled = false;
        gameObject.layer = 2;
        yield return new WaitForSeconds(3);
 //       Debug.Log("kill: wait to destroy zombi body 3 sec");
        Destroy(gameObject);
        
    }
}
