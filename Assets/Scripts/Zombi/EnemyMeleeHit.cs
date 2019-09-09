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
            //          StartCoroutine("EnemyAttack");
            //          other.GetComponent<PlayerStats>().PlayerHitted(damageToplayerOnHit, 0); // add - hp 
 //           anim.speed = 1;
            anim.SetTrigger("attack");
        }
    }
    
    

    private void OnTriggerStay(Collider other) // damage player every x second during stay close
    {
        if (other.gameObject.tag == "Player" /*&& other.gameObject != null */&& !isStarted)
        {
            //anim.ResetTrigger("attack");
  //          other.GetComponent<PlayerStats>().PlayerHitted(damageToplayerOnHit, 0);
            GameObject x = other.gameObject as GameObject;
            while (other.gameObject != null && !isStarted)
            { 
                StartCoroutine(EnemyAttack(x));
                isStarted = true;
                Debug.Log("stay in zombi range");
            }
        }
    }

    IEnumerator EnemyAttack(GameObject x) // wait before next attack
    {
        x.GetComponent<PlayerStats>().PlayerHitted(damageToplayerOnHit, 0);
        yield return new WaitForSeconds(1);
        isStarted = false;
//        Debug.Log("enumerator" + x.name);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //       anim.speed = 6;
            anim.SetTrigger("walk");
            //if (other.gameObject.tag == "Player" && other.gameObject != null)
            //{
            StopCoroutine("enemyAttack");
            //           Debug.Log("enumerator stopped");
        }
        //}
    }

    public void EnemyDeathAnim()
    {
 //       anim.speed = 1;
        anim.SetTrigger("fallingback");
 //       Debug.Log("fallingback anim");
    }

}
