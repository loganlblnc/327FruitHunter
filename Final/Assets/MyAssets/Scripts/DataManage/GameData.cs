using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class GameData :MonoBehaviour
{
    
    public enum scene
    {
        main, house, well, other
    }
    public static scene currentScene,prevScene;

     public static List<Food> f = new List<Food>();

    public static bool FPerson, TPerson;
    public static bool hasKey = false;
    public static bool hasEnteredWell=false;
    public static float timer;
    public static bool immune=false;
    public static bool startImmune=false;
    static int currHP;
    static int currPopints;
    static float n=0;


  
    public  void Update()
    {

        if (SceneManager.GetSceneByName("Main").isLoaded)
        {
            Cursor.visible = false;
            currentScene = scene.main;
        }

        else if (SceneManager.GetSceneByName("Well").isLoaded)
        {
            Cursor.visible = false;
            prevScene = scene.well;
            currentScene = scene.well;
        }
        else if (SceneManager.GetSceneByName("House").isLoaded)
        {
            Cursor.visible = false;
            prevScene = scene.house;
            currentScene = scene.house;
        }
        else if (SceneManager.GetSceneByName("House").isLoaded)
        {

        }
        else
        {
            currentScene = scene.other;
            Cursor.visible = true;
        }
        if (timer < 10f&&startImmune==true)
        {
            if (currentScene == scene.other)
            {
                startImmune = false;
                immune = false;
                timer = 0;
            }
            
            immune = true;
            timer += Time.deltaTime;
            n+=Time.deltaTime;
            if (n >= 1)
            {
                Score.score+=2;
                n = 0;
            }
            if (Score.health < currHP)
            {
                Score.health = currHP;
            }
            else if (Score.health > currHP)
            {
                currHP = Score.health;
            }
            if (Score.score < currPopints)
            {
                Score.score = currPopints;
            }
            else if (Score.score > currPopints)
            {
                currPopints = Score.score;
            }
        }
        if (timer > 10)
        {
            startImmune = false;
            immune = false;
            timer = 0;
        }
        /////////End Game/////////////
        ///
        if (endGame()) {

            restart();
            SceneManager.LoadScene("Menu_End"); }
        
    }
    public bool endGame()
    {
        if (isEaten("f1") && isEaten("f2") && isEaten("f3") && isEaten("f4") && isEaten("f5") && isEaten("f6") && isEaten("f7") 
            && isEaten("f10") && isEaten("f11") && isEaten("f12") ) return true;
        return false;
    }
    public static void addFood(string name)
    {
        f.Add(new Food(name));
    }
    public static bool isEaten(string name)
    {
        foreach(Food food in f)
        {
            if (food.name.Equals(name))
            {
                if (food.eaten) return true;
            }
        }
        return false;
    }
    public static void setEaten(string name,bool tf)
    {
        foreach (Food food in f)
        {
            if (food.name.Equals(name))
            {
                food.eaten = tf;
            }
        }
        
    }
    public static bool inList(string name)
    {
        foreach (Food food in f)
        {
            if (food.name.Equals(name))
            {
                return true;
            }
        }
        return false;
    }
    public static void restart()
    {
        currentScene = prevScene = scene.other;
        foreach(Food food in f)
        {
            food.eaten = false;
        }
        hasKey = false;
        hasEnteredWell = false;
    }
    public static void specialFood()
    {
        currHP = Score.health;
        currPopints = Score.score;
        startImmune = true;
        immune = true;
        timer = 0;
        n = 0;
    }
  

}
public class Food
{
    public string name;
    public bool eaten;
    public Food(string n)
    {
        name = n;
        eaten = false;
    }
    public void setEaten(bool tf)
    {
        this.eaten = tf;
    }
}
