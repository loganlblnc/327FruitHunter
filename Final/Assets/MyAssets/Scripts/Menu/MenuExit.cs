using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MenuExit : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void QuitGameButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit(); 
#endif

    }
    public void startButton()
    {
        Score.health = 100;
        GameData.startImmune = false;
        GameData.immune = false;
        GameData.timer = 0;
        Score.score = 0;
        GameData.restart();
        SceneManager.LoadScene("Main");
    }
}
