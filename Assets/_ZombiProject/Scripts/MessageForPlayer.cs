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
        player.GetComponent<PlayerStats>().MessageForPlayerMeth(messageForPlayerStr);
    }

    private void OnTriggerExit(Collider other)
    {
        player.GetComponent<PlayerStats>().MessageForPlayerMeth("");
    }
}
