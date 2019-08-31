using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour {

    [SerializeField]
    GameObject objToDestroy;
    [SerializeField]
    float timeBeforeDestroy = 1.0f;

	
	void Start () {
        Destroy(objToDestroy, timeBeforeDestroy);
	}
	
}
