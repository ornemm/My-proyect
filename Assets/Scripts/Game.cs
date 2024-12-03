using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    public static Game obj; //Static variable that refers to the Game script

    public int maxLives = 3;
    public int currentLives; 
    public int score = 0;

    public int scoreCoins = 00;    // Puntaje para crías
    public int scorePups = 000;    // Puntaje para crías

    public bool gamePaused = false;

    public TMP_Text scoreText; // Texto para mostrar el puntaje total
    public TMP_Text scoreTextCoins; // Texto para mostrar el puntaje de las monedas
    public TMP_Text scoreTextPups; // Texto para mostrar el puntaje de las crías

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
        // Reasignar referencias si es necesario
        if (scoreTextCoins == null) scoreTextCoins = GameObject.Find("ScoreTextCoins").GetComponent<TMP_Text>();
        if (scoreTextPups == null) scoreTextPups = GameObject.Find("ScoreTextPups").GetComponent<TMP_Text>();

        currentLives = maxLives;
        UpdateScoreTextCoins(); // Inicializar el texto de las monedas
        UpdateScoreTextPups(); // Inicializar el texto de las crías
    }

    // Método para agregar puntos de monedas
    public void AddCoinScore(int points)
    {
        scoreCoins += points;
        score += points; // Sumar al puntaje total
        Debug.Log("Puntos de monedas actual: " + scoreCoins);
        UpdateScoreTextCoins();
    }

    // Método para agregar puntos de crías
    public void AddPupScore(int points)
    {
        scorePups += points;
        score += points; // Sumar al puntaje total
        Debug.Log("Puntos de crías actual: " + scorePups);
        UpdateScoreTextPups();
    }

    public void AddScore(int points) // Método adicional para un puntaje genérico
    {
        score += points;
        Debug.Log("Puntaje total actual: " + score);
    }

    private void UpdateScoreTextCoins()
    {
        if (scoreTextCoins == null) scoreTextCoins = GameObject.Find("ScoreTextCoins").GetComponent<TMP_Text>();
        scoreTextCoins.text = scoreCoins.ToString();
    }

    private void UpdateScoreTextPups()
    {
        if (scoreTextPups == null) scoreTextPups = GameObject.Find("ScoreTextPups").GetComponent<TMP_Text>();
        scoreTextPups.text = scorePups.ToString();
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
    }


    public void ResetGameState()
    {
        score = 0;
        currentLives = maxLives;
        scoreCoins = 0;
        scorePups = 0;

        // Verificar los valores de las variables al reiniciar
        Debug.Log("Resetting Game State");
        Debug.Log("Score: " + score);
        Debug.Log("Lives: " + currentLives);

        //UpdateScoreTextCoins(); // Reiniciar el texto de las monedas
        //UpdateScoreTextPups(); // Reiniciar el texto de las crías
    }

    public void Win()
    {
        Debug.Log("Win");
        FindAnyObjectByType<GameOver>().ShowGameOver();
        //score = 0; //Reset the score
        //currentLives = maxLives;  //Restart lives
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

