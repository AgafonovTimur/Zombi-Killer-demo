using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanOpenTheDoor : MonoBehaviour {

    [SerializeField]
    GameObject GOwithTrigger;
    [SerializeField]
    string messageOne = "zombies to kill :  ";
    [SerializeField]
    string messageTwo = "";
    [SerializeField]
    string messageEmpty = ""; // empty always

    public List<GameObject> enemysLeft = new List<GameObject>();

    private void Start()
    {
        GOwithTrigger.GetComponent<BoxCollider>().enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (enemysLeft.Count == 0 && other.tag == "Player")
        {
            GOwithTrigger.GetComponent<BoxCollider>().enabled = true;
            other.GetComponent<PlayerStats>().MessageForPlayerOne(messageTwo);
        }

            if (other.gameObject.tag == "Player" && enemysLeft.Count > 0 )
        {
            other.GetComponent<PlayerStats>().MessageForPlayerDoors(messageOne, enemysLeft.Count);
            for (int i = 0; i < enemysLeft.Count; i++)
            {
                if (enemysLeft[i] == null)
                {
                    enemysLeft.RemoveAt(i);  
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        other.GetComponent<PlayerStats>().MessageForPlayerOne(messageEmpty);
    }
}
