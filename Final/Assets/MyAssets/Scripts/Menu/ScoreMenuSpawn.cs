using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMenuSpawn : MonoBehaviour {
    public string tag;
    public GameObject obj;
	// Use this for initialization
	void Start () {
        if (GameObject.FindGameObjectsWithTag(tag.ToString()).Length  <1)
        {
            Instantiate(obj, transform.position, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
