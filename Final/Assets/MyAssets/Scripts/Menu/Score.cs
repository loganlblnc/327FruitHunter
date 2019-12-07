using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public static int score = 0;
    public static int health = 100;
    public  AudioSource audio;
    public  AudioClip death,coin,bad,power;
    private void Start()
    {
        Score INSTANCE = this;
    }

    private void Update()
    {
        if (score < 0) score = 0;
        if (health <= 0) {
            audio.PlayOneShot(death);
            health = 1;
            SceneManager.LoadScene("Menu_Exit");
        }

    }
    public void play(string s)
    {
        if (s.Equals("Good")) audio.PlayOneShot(coin);
        if (s.Equals("Bad")) audio.PlayOneShot(bad);
        if (s.Equals("Special")) audio.PlayOneShot(power);

    }
    public void increaseScore(int amount)
    {
        score += amount;
    }
    public void dereaseScore(int amount)
    {
        score -= amount;
        if (score < 0) score = 0;
    }
    public int getScore()
    {
        return score;
    }
}
