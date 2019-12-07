using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerBackground : MonoBehaviour
{
    public float speed = 1;
    public int healthLost = 3;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back*speed*Time.deltaTime);


    }
    
}
