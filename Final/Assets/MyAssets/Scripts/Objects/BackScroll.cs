using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackScroll : MonoBehaviour
{
    
    public GameObject ob1, ob2;
    List<Transform> spawns = new List<Transform>();
    int difficulty, n;
    float time;
    // Use this for initialization
    void Start()
    {
        difficulty = 1;
        n = Random.Range(1, 5);
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
        if (Input.GetKeyDown("tab"))
        {
            SceneManager.LoadScene("Main");
        }
        if (time > n)
        {
            time = 0;
            n = Random.Range(1, 5);
            spawn();
        }
    }
    void spawn()
    {
        int funct = Random.Range(1, 3);

        switch (funct)
        {
            case (1):
                {
                    Instantiate(ob1, transform.position, Quaternion.identity);
                    break;
                }
            case (2):
                {
                    Instantiate(ob2, transform.position, Quaternion.identity);
                    break;
                }
            
        }
    }
}
