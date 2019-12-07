using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnController : MonoBehaviour {
    List<Transform> spawns = new List<Transform>();
    int difficulty,n;
	// Use this for initialization
	void Start () {
        difficulty = 1;
        n = 1;
        foreach(Transform spawn in GetComponentsInChildren<Transform>())
        {
            if (spawn.position != transform.position)
            {
                spawns.Add(spawn);
            }
        }
        InvokeRepeating("spawn", 1f, 1f);

    }
	
	// Update is called once per frame
	void Update () {
        n = Random.Range(0, 5);
        if (Input.GetKeyDown("tab"))
        {
            SceneManager.LoadScene("Main");
        }
	}
    void spawn()
    {
        int funct = Random.Range(1, 4);
        
        switch (funct)
        {
            case (1):
                {
                    int score = Random.Range(1, 4);
                    int health = Random.Range(1, 4);
                    spawns[n].GetComponent<SpawnObstacles>().spawnGood(score,score*health);
                    break;
                }
            case (2):
                {
                    int score = Random.Range(-8, -1);
                    int health = Random.Range(2, 4);
                    spawns[n].GetComponent<SpawnObstacles>().spawnBad(score, score * health);
                    break;
                }
            case (3):
                {
                    
                    spawns[n].GetComponent<SpawnObstacles>().spawnObstacle();
                    break;
                }
        }
    }
}
