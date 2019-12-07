using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstRunner : MonoBehaviour {
    public float speed=1;
    public int healthLost=3;
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0,0,-speed * Time.deltaTime));
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            player.GetComponent<Runner>().untouchable();
            Score.health -= healthLost;
            Destroy(gameObject);
        }
    }
}
