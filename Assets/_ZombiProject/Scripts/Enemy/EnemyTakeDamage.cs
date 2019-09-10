using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// when zombi recieve damage
public class EnemyTakeDamage : MonoBehaviour {

    [SerializeField]
    public float health = 100;
    
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

    IEnumerator KillZombi ()
    {
        yield return new WaitForSeconds(3);
 //       Debug.Log("kill: wait to destroy zombi body 3 sec");
        Destroy(gameObject);
        
    }
}
