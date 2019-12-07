using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour {
    Animator anim;
    bool hittingFloor = true;//jump var
    List<Vector3> waypoints = new List<Vector3>();
    int curr;
    float speed;
    public float gravity=.5f;
    public float jump = 5f;
    public float MaxSpeed = 2f;
    bool grounded;
    Vector3 startingPos;
    public Collider collider;
    SkinnedMeshRenderer rend;

    float timer;
    bool untouch;
    // Use this for initialization
    void Start () {
        speed = MaxSpeed;
        curr = 1;
        waypoints.Add(GameObject.Find("WPL").transform.position);
        waypoints.Add(GameObject.Find("WPM").transform.position);
        waypoints.Add(GameObject.Find("WPR").transform.position);
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        startingPos = transform.position;
        grounded = true;

        collider = GetComponent<Collider>();
        untouch=false;
        rend = GetComponentInChildren<SkinnedMeshRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (untouch)
        {

            if (rend.enabled) rend.enabled = false;
            else rend.enabled = true;
            timer += Time.deltaTime;

        }
        else { collider.enabled = true;
            rend.enabled = true;
        }
        if (timer > 2) {
            timer = 0;
            untouch = false;
        }
        if (Input.GetKeyDown("a"))
        {
            if (curr>0)
            {
                curr--;
            }
            
        }
        if (Input.GetKeyDown("d"))
        {
            if (curr < 2)
            {
                curr++;
            }

        }
        if (transform.position.x != waypoints[curr].x)
        {
            Vector3 dir = waypoints[curr] - transform.position;
            transform.Translate(new Vector3(dir.x, 0, 0)*Time.deltaTime*speed);
        }
        if (transform.position.y !=startingPos.y&&!grounded&& transform.position.y - startingPos.y > .1)
        {
            transform.Translate(new Vector3(0, -gravity, 0) * Time.deltaTime * speed);
        }
        else if (transform.position.y - startingPos.y<.2)
        {
            grounded = true;
        }
        if (Input.GetKeyDown("space")&&grounded)
        {
            transform.position = new Vector3(transform.position.x, jump, transform.position.z);
            grounded = false;
        }
    }
   public void untouchable()
    {
        collider.enabled = false;
        untouch = true;
        timer = 0;
    }
}
