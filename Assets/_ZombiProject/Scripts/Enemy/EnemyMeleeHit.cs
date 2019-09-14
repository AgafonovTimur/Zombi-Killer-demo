using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// zombi deal damage
public class EnemyMeleeHit : MonoBehaviour {

    [SerializeField]
    private  GameObject player;
    [SerializeField]
    int damageToplayerOnHit = 10;
    Animator anim;
    bool isStarted;

    private void Start()
    {
        anim = GetComponent<Animator>();
//        anim.speed = 2;
        anim.SetTrigger("walk");
    }
    
    private void OnTriggerEnter(Collider other) // 1 attack to player
    {
        if (other.gameObject.tag == "Player") // && other.gameObject != null)
        {
            anim.SetTrigger("attack");
        }
    }
    
    

    private void OnTriggerStay(Collider other) // damage player every x second during stay close
    {
        if (other.gameObject.tag == "Player" && !isStarted)
        {
            GameObject x = other.gameObject as GameObject;
            while (other.gameObject != null && !isStarted)
            { 
                StartCoroutine(EnemyAttack(x));
                isStarted = true;
            }
        }
    }

    IEnumerator EnemyAttack(GameObject x) // wait before next attack 1 sec
    {
        x.GetComponent<PlayerStats>().PlayerHitted(damageToplayerOnHit, 0);
        yield return new WaitForSeconds(1);
        isStarted = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //       anim.speed = 6;
            anim.SetTrigger("walk");
            StopCoroutine("enemyAttack");

        }
    }

    public void EnemyDeathAnim()
    {
 //       anim.speed = 1;
        anim.SetTrigger("fallingback");
    }

}
