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
 //   public Transform player;
    NavMeshAgent zombi;


    void Start () {

        zombi = GetComponent<NavMeshAgent>();

	}


    void Update()
    {
        //if (Vector3.Distance(transform.position, player.position) >= minDistance)
        //{
        //    Vector3 playerPos = new Vector3 (player.transform.position.x, player.transform.position.y - 1f, player.transform.position.z);
        //    transform.LookAt(playerPos);
        //    zombi.destination = player.transform.position * zombiMoveSpeed;
        //}

        //if (Vector3.Distance(transform.position, player.position) <= maxDistance)
        //{

        //}

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
