
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{

    Animator anim;
    bool doorOpen;

    void Start()
    {
        doorOpen = false;
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && doorOpen == false)
        {
            doorOpen = true;
            DoorControl("Up");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            doorOpen = false;
            DoorControl("Down");
        }
    }

    void DoorControl(string direction)
    {
        anim.SetTrigger(direction);
    }
}
