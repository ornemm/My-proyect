using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game obj; //Static variable that refers to the Game script

    public int maxLives = 3;
    public int currentLives; 
    public int score = 0;

    public bool gamePaused = false;

    void Awake()
    {
        if (obj == null)
        {
            obj = this; //Assign this Game instance to the static variable obj
            DontDestroyOnLoad(gameObject); // Prevents it from being destroyed when loading new scenes
        }
        else
        {
            Destroy(gameObject); //If an instance already exists, destroy this object
        }
    }

    void Start()
    {
        currentLives = maxLives;
    }

    // Method to add points
    public void AddScore(int scoreGive)
    {
        score += scoreGive;
        Debug.Log("Puntos actual: " + score);
    }

    public void GainLife()
    {
        currentLives++;
        Debug.Log("Vidas actuales: " + currentLives);
    }

    public void LoseLife()
    {
        currentLives--;
        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        score = 0; //Reset the score
        currentLives = maxLives;  //Restart lives
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Win()
    {
        Debug.Log("Win");
        score = 0; //Reset the score
        currentLives = maxLives;  //Restart lives
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

