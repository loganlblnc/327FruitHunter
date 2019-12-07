
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdController : MonoBehaviour
{
    Animator anim;
    public float speed = 3.0f;
    public float jumpHeight = 2;
    public float rotateSpeed = 5;
    public enum State
        
    {
        idle, walking, jumping, jumpingProgress
    }
    State playerState;


    private float time;//Time before going back to idle
    bool hittingFloor = true;//jump var
    Rigidbody rb;
    Vector3 jump;

    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////
    /// </summary>
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        playerState = State.idle;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            transform.Rotate(0, -rotateSpeed*Time.deltaTime, 0);
        }
        if (Input.GetKey("d"))
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }

        switch (playerState)
        {
            case (State.idle):
                {
                    anim.SetBool("isIdle", true);
                    anim.SetBool("isWalking", false);
                    anim.SetBool("isJumping", false);
                    if (Input.GetAxis("Vertical") != 0)
                    {
                        playerState = State.walking;
                        time = 0;
                        break;
                    }
                    if (Input.GetKeyDown("space") && hittingFloor)
                    {
                        time = 0;
                        jump = new Vector3(transform.position.x, transform.position.y + jumpHeight, transform.position.z);
                        playerState = State.jumping;
                        break;
                    }
                    break;
                }

            case (State.walking):
                {
                    anim.SetBool("isIdle", false);
                    anim.SetBool("isWalking", true);
                    anim.SetBool("isJumping", false);

                    if ((!Input.GetKey("w") || !Input.GetKey("s")) && time > .5)
                    {
                        playerState = State.idle;
                        time = 0;
                        break;
                    }
                    if (Input.GetKeyDown("space") && hittingFloor)
                    {
                        jump = new Vector3(transform.position.x, transform.position.y + jumpHeight, transform.position.z);
                        playerState = State.jumping;
                        time = 0;
                        break;
                    }
                    time += Time.deltaTime;
                    float translation = Input.GetAxis("Vertical") * speed;
                    float straffe = Input.GetAxis("Horizontal") * speed;
                    translation *= Time.deltaTime;
                    straffe *= Time.deltaTime;
                    transform.Translate(straffe, 0, translation);
                    break;
                }
            case (State.jumping):
                {
                    anim.SetBool("isIdle", false);
                    anim.SetBool("isWalking", false);
                    anim.SetBool("isJumping", true);
                    jump = new Vector3(0, jumpHeight, 0);
                    rb.AddForce(jump, ForceMode.Impulse);
                    hittingFloor = false;
                    playerState = State.walking;

                    break;
                }
        }

        //Escape
        if (Input.GetKeyDown("escape")) Cursor.lockState = CursorLockMode.None;

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Floor")
            hittingFloor = true;
        if (collision.transform.tag == "Enemy")
        {
            if (collision.transform.GetComponent<kobold>().getState() == "FoundPlayer" && GameData.immune == false)
            {
                Score.health -= 1;

            }
        }
    }

}
