using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGood : MonoBehaviour {
    public int score = 1;
    public int health = 10;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Score scr = GameObject.Find("GameData").GetComponent<Score>();
            Score.score+=this.score;
            int temp = Score.health;
            Score.health += this.health;
            if (temp < Score.health) scr.play("Good");
            else scr.play("Bad");
            
            gameObject.GetComponentInParent<ParentFood>().setEaten(true);
            Destroy(transform.gameObject);
        }
    }
}
