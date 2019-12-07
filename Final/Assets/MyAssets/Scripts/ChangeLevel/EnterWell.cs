using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterWell : MonoBehaviour {
    bool near = false;
    private void Update()
    {
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) < 2 &&
            GameObject.Find("Cactus").GetComponent<Chat>().isTalking == false)
        {
            GameObject.Find("Canvas").GetComponentInChildren<Text>().text = "Tab to enter well";
            near = true;
        }
        else if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) > 2&&near==true)
        {
            GameObject.Find("Canvas").GetComponentInChildren<Text>().text = "";
            near = false;
        }
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) < 2 && Input.GetKeyDown("tab")&&
            (Score.score>=25||GameData.hasEnteredWell==true))
        {
            GameObject.Find("Canvas").GetComponentInChildren<Text>().text = "";
            GameData.hasEnteredWell = true;
            SceneManager.LoadScene("Well");

        }
        else if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) < 2 && Input.GetKeyDown("tab") &&
            Score.score < 25&&GameData.hasEnteredWell==false)
        {
            GameObject.Find("Cactus").GetComponent<Chat>().setStart();

        }
    }
 
}
