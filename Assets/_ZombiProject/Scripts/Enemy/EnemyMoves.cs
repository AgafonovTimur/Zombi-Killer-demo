using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoves : MonoBehaviour
{

    [SerializeField]
    float maxDistance = 10.0f;
    [SerializeField]
    float minDistance = 2.5f;
    [SerializeField]
    float zombiMoveSpeed = 1.0f;
    //   public Transform player;
    //[SerializeField]
    GameObject player;
    NavMeshAgent zombi;


    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        zombi = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        Vector3 playerPos = new Vector3(player.transform.position.x,
                                        player.transform.position.y - 0.9f,
                                        player.transform.position.z);

        if (Vector3.Distance(transform.position, player.transform.position) >= minDistance &&
            Vector3.Distance(transform.position, player.transform.position) < maxDistance)
        {
            maxDistance = 100f;
            transform.LookAt(playerPos);
            transform.position += transform.forward * zombiMoveSpeed * Time.deltaTime;
        }
        if (Vector3.Distance(transform.position, player.transform.position) < minDistance)
        {
            transform.LookAt(playerPos);
        }
        if (Vector3.Distance(transform.position, player.transform.position) > maxDistance)
        {

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Bullet(Clone)")
        {
            maxDistance = 100f;
        }
    }
}


        //private void OnCollisionStay(Collision collision)
        //{
        //    Vector3 playerPos = new Vector3(player.transform.position.x,
        //                                    player.transform.position.y - 0.9f,
        //                                    player.transform.position.z);

        //    if (Vector3.Distance(zombiGO.transform.position, player.transform.position) >= minDistance &&
        //        Vector3.Distance(zombiGO.transform.position, player.transform.position) < maxDistance)
        //    {

        //        zombiGO.transform.LookAt(playerPos);
        //        zombiGO.transform.position += transform.forward * zombiMoveSpeed * Time.deltaTime;
        //    }
        //    if (Vector3.Distance(zombiGO.transform.position, player.transform.position) < minDistance)
        //    {
        //        transform.LookAt(playerPos);
        //    }
        //    if (Vector3.Distance(zombiGO.transform.position, player.transform.position) > maxDistance)
        //    {

        //    }
        //}


        //}
        //if (player != null)
        //{
        //    zombi.destination = player.transform.position * zombiMoveSpeed;
        //}
        //if (player = null)
        //{
        //    Debug.Log("player lull");
        //}
        //       Debug.Log(zombi.destination + "" + player.transform.position);
        //if (Vector3.Distance(transform.position, player.position) >= minDistance)
        //{
        //    Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y - 1f, player.transform.position.z);
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


    
