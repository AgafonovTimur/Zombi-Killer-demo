using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageForPlayer : MonoBehaviour {

    [SerializeField]
    string messageForPlayerStr;
    [SerializeField]
    GameObject player;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            player.GetComponent<PlayerStats>().MessageForPlayerOne(messageForPlayerStr);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            player.GetComponent<PlayerStats>().MessageForPlayerOne("");
    }
}
