using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour {
    public GameObject goodFood, badFood, obst;
	// Use this for initialization
	public void spawnGood(int score,int health)
    {
        goodFood.GetComponent<RunnerFood>().health = health;
        goodFood.GetComponent<RunnerFood>().score = score;
        Instantiate(goodFood, transform.position, Quaternion.identity);
    }
    public void spawnBad(int score, int health)
    {
        badFood.GetComponent<RunnerFood>().health = health;
        badFood.GetComponent<RunnerFood>().score = score;
        Instantiate(badFood, transform.position, Quaternion.identity);
    }
    public void spawnObstacle()
    {
        Instantiate(obst, transform.position, Quaternion.identity);
    }
}
