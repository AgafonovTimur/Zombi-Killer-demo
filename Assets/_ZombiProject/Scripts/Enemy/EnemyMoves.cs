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
    float distance;


    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        zombi = GetComponent<NavMeshAgent>();
        
    }

    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);  
        Vector3 playerPos = new Vector3(player.transform.position.x,                //zombie look higher at hero
                                        player.transform.position.y - 0.9f,
                                        player.transform.position.z);

        //if (Vector3.Distance(transform.position, player.transform.position) >= minDistance &&
        //    Vector3.Distance(transform.position, player.transform.position) < maxDistance)
        if (distance >= minDistance && distance < maxDistance)
            {
            maxDistance = 100f;
            transform.LookAt(playerPos);
            transform.position += transform.forward * zombiMoveSpeed * Time.fixedDeltaTime;
        }
        if (distance < minDistance)
        {
            transform.LookAt(playerPos);
        }
        if (distance > maxDistance) { }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Bullet(Clone)")
        {
            maxDistance = 100f;
        }
    }
}
    
