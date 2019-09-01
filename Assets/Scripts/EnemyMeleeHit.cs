using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// zombi deal damage
public class EnemyMeleeHit : MonoBehaviour {

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
        if (other.gameObject.tag == "Hero")
        {
            
            anim.SetTrigger("attack");

            hero.GetComponent<HeroStats>().HeroHitted(damageToHeroOnHit);
        //    Debug.Log(damageToHeroOnHit);
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        {
            anim.SetTrigger("walk");
        }

    }
    public void enemyDeathAnim()
    {
        anim.SetTrigger("fallingback");
       // Debug.Log("fallingback anim");
    }

}
