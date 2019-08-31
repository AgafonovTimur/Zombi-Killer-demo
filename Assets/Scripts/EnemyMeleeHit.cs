using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeHit : MonoBehaviour {

    [SerializeField]
    private  GameObject rightHand;
    [SerializeField]
    private  GameObject leftHand;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hero")
        {
            Invoke("hitTheHero",1);
            print("bbb");
        }
    }
    private void hitTheHero()
    {
        print("123");
    }
}
