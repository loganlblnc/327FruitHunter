using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFood : MonoBehaviour {
    public static bool eaten;
    public GameObject food;
	// Use this for initialization
	void Start () {
        if (!GameData.inList(name)) GameData.addFood(name);
        if (GameData.isEaten(name)==true)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
     
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 250 * Time.deltaTime, 0);
	}
    public void setEaten(bool tf)
    {
        GameData.setEaten(name, tf);
        
    }
}
