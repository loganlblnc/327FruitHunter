using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject player;
    public GameObject playerThird;
    // Use this for initialization
    void Awake () {
        if (GameData.prevScene != GameData.scene.house)
        {
            if (GameData.FPerson)
            {
                Instantiate(player, new Vector3(168f, .5f, 125f), Quaternion.identity);
            }
            else Instantiate(playerThird, new Vector3(168f, .5f, 125f), Quaternion.identity);
        }

        else
        {
            if (GameData.FPerson)
            {
                Instantiate(player, new Vector3(182, .5f, 121), Quaternion.identity);
            }
            else Instantiate(playerThird, new Vector3(182, .5f, 121), Quaternion.identity);
        }
	}
	
	
}
