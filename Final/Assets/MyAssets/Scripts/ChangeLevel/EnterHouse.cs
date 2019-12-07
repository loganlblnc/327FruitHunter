using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterHouse : MonoBehaviour
{
    bool near = false;

    private void Update()
    {
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) < 2)
        {
            GameObject.Find("Canvas").GetComponentInChildren<Text>().text = "Tab to enter house";
            near = true;
        }
        else if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) > 2 && near == true)
        {
            GameObject.Find("Canvas").GetComponentInChildren<Text>().text = "";
            near = false;
        }
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) < 2 && Input.GetKeyDown("tab") &&
            GameData.hasKey == true)
        {
            GameObject.Find("Canvas").GetComponentInChildren<Text>().text = "";

            SceneManager.LoadScene("House");

        }
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) < 2 && Input.GetKeyDown("tab") &&
            GameData.hasKey == false)
        {
            GameObject.Find("Canvas").GetComponentInChildren<Text>().text = "Hmm, I need a key";

        }
    }
}
