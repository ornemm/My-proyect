using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game obj;  // Variable estática que hace referencia al script Game

    public int maxLives = 3;
    public int currentLives; 
    public int score = 0;

    public bool gamePaused = false;

    void Awake()
    {
        if (obj == null)
        {
            obj = this;  // Asigna esta instancia de Game a la variable estática obj
            DontDestroyOnLoad(gameObject);  // Evita que se destruya al cargar nuevas escenas
        }
        else
        {
            Destroy(gameObject);  // Si ya existe una instancia, destruye este objeto
        }
    }

    void Start()
    {
        currentLives = maxLives;
    }

    // Método para sumar puntos
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
        score = 0;  // Reiniciar el puntaje
        currentLives = maxLives;  // Reiniciar las vidas
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

