using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int score = 0;
    public int health = 0;
    private void Update()
    {
        transform.Rotate(0, 5*Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Score sc = GameObject.Find("GameData").GetComponent<Score>();
            Score.score += this.score;
            Score.health += this.health;
            sc.play("Good");
            gameObject.GetComponentInParent<ParentFood>().setEaten(true);
            GameData.hasKey = true;
            Destroy(transform.gameObject);
        }
    }
}
