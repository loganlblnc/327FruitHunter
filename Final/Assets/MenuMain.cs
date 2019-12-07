using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuMain : MonoBehaviour {
     Toggle FP,TP;
	// Use this for initialization
	void Start () {
        FP = transform.Find("1P").GetComponent<Toggle>();
        TP = transform.Find("3P").GetComponent<Toggle>();
        FP.isOn = true;
        TP.isOn = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (FP.isOn == true)
        {
            GameData.FPerson = true;
            GameData.TPerson = false;
        }
        if (TP.isOn == true)
        {
            GameData.TPerson = true;
            GameData.FPerson = false;
        }
	}
}
