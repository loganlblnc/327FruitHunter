using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUpdate : MonoBehaviour {
    Slider slide;
    private void Start()
    {
        slide = gameObject.GetComponent<Slider>();
    }
    private void Update()
    {
        slide.value = (float)Score.health/100;
        transform.GetChild(2).GetComponent<Text>().text = Score.health.ToString();
    }

}
