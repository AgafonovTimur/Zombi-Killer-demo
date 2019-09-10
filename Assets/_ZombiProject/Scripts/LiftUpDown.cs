
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftUpDown : MonoBehaviour
{

    Animator anim;
    bool liftUp;
    [SerializeField]
    float animSpeed = 1f;
    [SerializeField]
    string liftDerectionFirst = "Up";
    [SerializeField]
    string liftDerectionSecond = "Down";

    void Start()
    {
        liftUp = false;
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && liftUp == false)
        {
            liftUp = true;
            LiftControl(liftDerectionFirst, animSpeed);  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            liftUp = false;
            LiftControl(liftDerectionSecond, animSpeed); 
        }
    }

    void LiftControl(string direction, float speed)
    {
        anim.SetTrigger(direction);
        anim.speed = animSpeed;
        Debug.Log(animSpeed);
    }
}
