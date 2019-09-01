using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiAnimations : MonoBehaviour {

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger("attack");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("startWalk");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            anim.SetTrigger("death");
        }
    }
}
