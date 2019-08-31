using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoves : MonoBehaviour {

    
    float maxDistance = 10.0f;
    [SerializeField]
    float minDistance = 1.5f;
    [SerializeField]
    float enemyMoveSpeed = 1.0f;
    public Transform hero;

	void Start () {
		
	}


    void Update()
    {
        transform.LookAt(hero);

        if (Vector3.Distance(transform.position, hero.position) >= minDistance)
        {

            transform.position += transform.forward * enemyMoveSpeed * Time.deltaTime;



            if (Vector3.Distance(transform.position, hero.position) <= maxDistance)
            {

            }
        }
    }
}
