using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// zombi deal damage
public class EnemyMeleeHit : MonoBehaviour {

    [SerializeField]
    private  GameObject hero;
    [SerializeField]
    int damageToHeroOnHit = 10;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("idle");
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hero" && other.gameObject != null)
        {
            StartCoroutine("enemyAttack");
            other.GetComponent<HeroStats>().HeroHitted(damageToHeroOnHit, 0); // add armor 
            anim.SetTrigger("attack");
        }
    }
    
    IEnumerator enemyAttack ()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        transform.GetChild(0).gameObject.SetActive(true);
        //transform.GetChild(0).Translate(new Vector3(0, 0, -0.2f), Space.Self);
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == null)
        {
            //anim.ResetTrigger("attack");
            anim.SetTrigger("walk");
            StopCoroutine("enemyAttack");
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Hero")
    //    {
    //        anim.SetTrigger("walk");
    //        StopCoroutine("enemyAttack");
    //    }

    //}
    public void enemyDeathAnim()
    {
        anim.SetTrigger("fallingback");
       // Debug.Log("fallingback anim");
    }

}
