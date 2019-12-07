using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int score = Score.score + Score.health;
        GetComponent<Text>().text = "Total Score is: " + score;
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
