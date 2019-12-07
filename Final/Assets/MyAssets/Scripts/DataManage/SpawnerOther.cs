using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerOther : MonoBehaviour {
    public Vector3 pos;
    public GameObject Player,playerThird;
	// Use this for initialization
	void Start () {
        if (GameData.FPerson)
        {
            Instantiate(Player, pos, Quaternion.identity);
        }
        else Instantiate(playerThird, pos, Quaternion.identity);
    }
	
	
}
