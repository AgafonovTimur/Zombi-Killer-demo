using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// when zombi recieve damage
public class ZombiTakeDamage : MonoBehaviour {

    [SerializeField]
    public float health = 100;
    
    public void TakeDamage(float ammount)
    {
        health -= ammount;
        if (health <= 0f)
        {
            gameObject.GetComponent<EnemyMeleeHit>().EnemyDeathAnim();
            StartCoroutine(KillZombi());
            Debug.Log("kill 1");
        }
    }

    IEnumerator KillZombi ()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
        Debug.Log("kill 2");
    }
}
