using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour {
    public float speed=.5f;
    public Renderer rend;
    Vector2 pos;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
         pos = Vector2.zero;

    }
	
	// Update is called once per frame
	void Update () {
        pos.y -= speed * Time.deltaTime;
        rend.material.SetTextureOffset("_MainTex",pos);
       
		
	}
}
