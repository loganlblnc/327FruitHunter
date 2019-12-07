using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam3rd : MonoBehaviour
{
    Vector2 mouseLook;
    Vector2 smoothV;
    GameObject character;

    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
    // Use this for initialization
    void Start()
    {
        character = this.transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        //Camera
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;
        if (mouseLook.y < 120 && mouseLook.y > -20)
        {
            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            
        }

    }
}
