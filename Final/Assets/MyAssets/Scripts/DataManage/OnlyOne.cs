using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyOne : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        if (GameObject.FindGameObjectsWithTag(transform.tag).Length > 1)
        {
            Destroy(gameObject);
        }
    }
	
	
}
