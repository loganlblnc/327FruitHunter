using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaveWell : MonoBehaviour {

    private void Update()
    {
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) < 2)
        {
            GameObject.Find("Canvas").GetComponentInChildren<Text>().text = "Tab to leave well";
        }
        else if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) > 2)
        {
            GameObject.Find("Canvas").GetComponentInChildren<Text>().text = "";
        }
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) < 2 && Input.GetKeyDown("tab"))
        {
            GameObject.Find("Canvas").GetComponentInChildren<Text>().text = "";
            SceneManager.LoadScene("Main");
        }
    }
}
