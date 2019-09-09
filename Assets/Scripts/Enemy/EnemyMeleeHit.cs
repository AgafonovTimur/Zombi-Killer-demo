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

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("idle");
    }
    
    private void OnTriggerEnter(Collider other) // 1 attack to player
    {
        if (other.gameObject.tag == "Player" && other.gameObject != null)
        {
  //          StartCoroutine("EnemyAttack");
            other.GetComponent<PlayerStats>().PlayerHitted(damageToplayerOnHit, 0); // add - hp 
            anim.SetTrigger("attack");
        }
    }
    
    IEnumerator EnemyAttack () // wait before next attack
    {
        //     transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        Debug.Log("enumerator 2");
        //      transform.GetChild(0).gameObject.SetActive(true);
        //transform.GetChild(0).Translate(new Vector3(0, 0, -0.2f), Space.Self);

    }
    private void OnTriggerStay(Collider other) // damage player every x second during stay close
    {
        if (other.gameObject.tag == "Player" && other.gameObject != null)
        {
            //anim.ResetTrigger("attack");
 //           anim.SetTrigger("attack");
            StartCoroutine("EnemyAttack");
            Debug.Log("stay in zombi range");
  //          StopCoroutine("enemyAttack");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        anim.SetTrigger("walk");
        //if (other.gameObject.tag == "Player" && other.gameObject != null)
        //{
            StopCoroutine("enemyAttack");
            Debug.Log("enumerator stopped");
        //}
    }
    public void EnemyDeathAnim()
    {
        anim.SetTrigger("fallingback");
        Debug.Log("fallingback anim");
    }

}
