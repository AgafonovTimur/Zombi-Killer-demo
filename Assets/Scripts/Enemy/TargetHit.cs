using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// when zombi recieve damage
public class TargetHit : MonoBehaviour {

    [SerializeField]
    public float health = 100;
    
    public void TakeDamage(float ammount)
    {
        health -= ammount;
        if (health <= 0f)
        {
            gameObject.GetComponent<EnemyMeleeHit>().enemyDeathAnim();
            StartCoroutine(KillEnemy());
        }
    }

    IEnumerator KillEnemy ()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
