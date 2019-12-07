using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour {
    GameObject player;
    Camera chatCam, playerCam;
    float time;
    bool start;
    public bool isTalking;
	// Use this for initialization
	void Start () {
        start = false;
        isTalking = false;
        player = GameObject.FindGameObjectWithTag("Player");
        chatCam = GetComponentInChildren<Camera>();
        chatCam.enabled = false;
        playerCam = player.GetComponentInChildren<Camera>();
        time = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (start)
        {
            isTalking = true;
            chatCam.enabled = true;
            playerCam.enabled = false;
            player.GetComponent<FirstPersonController>().enabled = false;
            if (Input.GetKeyDown("space"))
            {
                GameObject.Find("Canvas").GetComponentInChildren<Text>().text = "";
                this.start = false;
                time = time = 0;
                playerCam.enabled = true;
                chatCam.enabled = false;
                isTalking = false;
                player.GetComponent<FirstPersonController>().enabled = true;
                return;
            }
            
            if(time<=3) GameObject.Find("Canvas").GetComponentInChildren<Text>().text = "Woah, you think you can just walk into my Well?";
            else if (time > 3&&time<=6) GameObject.Find("Canvas").GetComponentInChildren<Text>().text = "Tell you what, prove you are strong enough and you can go in";
            else if (time>6&&time<9) GameObject.Find("Canvas").GetComponentInChildren<Text>().text =
                    "Come back when your score is atleast 25";
            else if (time >= 9)
            {
                GameObject.Find("Canvas").GetComponentInChildren<Text>().text = "";
                this.start = false;
                time = time = 0;
                playerCam.enabled = true;
                chatCam.enabled = false;
                isTalking = false;
                player.GetComponent<FirstPersonController>().enabled = true;
            }
            time += Time.deltaTime;
        }
		
	}
    public void setStart()
    {
        this.start = true;
        isTalking = true;
        time = 0;
    }
}
