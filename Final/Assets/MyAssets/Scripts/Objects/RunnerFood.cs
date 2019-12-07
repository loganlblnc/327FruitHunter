using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerFood : MonoBehaviour {
    GameObject player;
    public float speed=1f;
    public int score;
    public int health;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (transform.position.z-player.transform.position.z < .8f&& transform.position.z - player.transform.position.z>0 && Mathf.Abs( transform.position.x - player.transform.position.x) < .8&&
           Mathf.Abs(transform.position.y - player.transform.position.y) < .8)
        {
            int temp = Score.score;
            Score sc = GameObject.Find("GameData").GetComponent<Score>();
            Score.score += this.score;
            Score.health += this.health;
            if (temp < Score.score) sc.play("Good");
            else sc.play("Bad");
            Destroy(transform.gameObject);
        }
	}
}
