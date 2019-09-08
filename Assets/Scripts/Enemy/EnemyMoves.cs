using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoves : MonoBehaviour {

    
    float maxDistance = 10.0f;
    [SerializeField]
    float minDistance = 1.5f;
    [SerializeField]
    float zombiMoveSpeed = 1.0f;
    public Transform hero;
    NavMeshAgent zombi;


    void Start () {

        zombi = GetComponent<NavMeshAgent>();

	}


    void Update()
    {
        if (Vector3.Distance(transform.position, hero.position) >= minDistance)
        {
            Vector3 heroPos = new Vector3 (hero.transform.position.x, hero.transform.position.y - 1f, hero.transform.position.z);
            transform.LookAt(heroPos);
            zombi.destination = hero.transform.position * zombiMoveSpeed;
        }

        if (Vector3.Distance(transform.position, hero.position) <= maxDistance)
        {

        }

        //transform.LookAt(hero.transform);

        //if (Vector3.Distance(transform.position, hero.position) >= minDistance)
        //{
        //    transform.position += transform.forward * enemyMoveSpeed * Time.deltaTime;
        //}

        //if (Vector3.Distance(transform.position, hero.position) <= maxDistance)
        //{

        //}

    }
}
