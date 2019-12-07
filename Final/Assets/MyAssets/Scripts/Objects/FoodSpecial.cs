using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpecial : MonoBehaviour {
    Color red, blue, yellow;
    MeshRenderer rend;
    
	// Use this for initialization
	void Start () {
        red = Color.red;
        blue = Color.blue;
        yellow = Color.yellow;
        rend = GetComponentInChildren<MeshRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
        int n = Random.RandomRange(1, 4);
        if (n == 1) rend.material.color = red;
        if (n == 2) rend.material.color = blue;
        if (n == 3) rend.material.color = yellow;
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) < 1.5)
        {
            Score scr = GameObject.Find("GameData").GetComponent<Score>();
            GameData.specialFood();
            scr.play("Special");
            gameObject.GetComponentInParent<ParentFood>().setEaten(true);
            Destroy(gameObject);
        }

    }
}
