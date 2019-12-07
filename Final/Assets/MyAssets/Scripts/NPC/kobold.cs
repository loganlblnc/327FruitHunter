using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kobold : MonoBehaviour {
    List<Transform> path = new List<Transform>();
    Transform player;
    public string pathName;
    int curr;
    public enum state
    {
        walk, foundPlayer
    }
    state playerState;
	// Use this for initialization
	void Start () {
        playerState = state.walk;
        curr = 0;
        path =GameObject.Find(pathName).GetComponent<Path>().pathlist;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

    // Update is called once per frame
    void Update()
    {
        switch (playerState)
        {
            case (state.walk):
                {
                    if (Vector3.Distance(transform.position, path[curr].position) < 1)
                    {
                        if (curr < path.Count - 1)
                            curr++;
                        else curr = 0;
                    }
                    Vector3 dir = path[curr].position - transform.position;
                    dir.y = 0;
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 1f);

                    transform.Translate(0, 0, Time.deltaTime);
                    if (Vector3.Distance(transform.position, player.position) < 4&& Vector3.Distance(transform.position,
                        GameObject.Find(pathName).GetComponent<Path>().transform.position) < 4.5f)
                        playerState = state.foundPlayer;
                    //Debug.Log(Vector3.Distance(transform.position, player.position));
                    break;
                }
            case (state.foundPlayer):
                {
                    if (Vector3.Distance(transform.position, player.position) > 5.2|| Vector3.Distance(transform.position, 
                        GameObject.Find(pathName).GetComponent<Path>().transform.position) > 4.8)
                        playerState = state.walk;
                    Vector3 dir = player.position - transform.position;
                    dir.y = 0;
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 1f);

                    transform.Translate(0, 0, 1.8f * Time.deltaTime);

                    break;
                }

        }
        
    }
    public string getState()
    {
        if (playerState == state.foundPlayer) return "FoundPlayer";
        else return "Walking";
    }
}
