using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour {

    [SerializeField]
    public float health = 50;
    
    public void TakeDamage(float ammount)
    {
        health -= ammount;
        if (health <= 0f)
            KillEnemy();
    }

    void KillEnemy()
    {
        Destroy(gameObject);
    }
}
