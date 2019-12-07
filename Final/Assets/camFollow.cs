using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class camFollow : MonoBehaviour {
    Transform player;
	// Use this for initialization
	void Start () {
        try
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        catch (Exception e) { }
	}
	
	// Update is called once per frame
	void Update () {
        try
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        }
        catch(Exception e)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

	}
}
