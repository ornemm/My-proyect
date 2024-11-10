using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Game : MonoBehaviour
{
    public static Game obj;  // Variable est�tica que hace referencia al script Game

    public int Heart = 3;
    public int currentLives;
    public bool gamePaused = false;
    public int score = 0;

    void Awake()
    {
        if (obj == null)
        {
            obj = this;  // Asigna esta instancia de Game a la variable est�tica obj
            DontDestroyOnLoad(gameObject);  // Evita que se destruya al cargar nuevas escenas
        }
        else
        {
            Destroy(gameObject);  // Si ya existe una instancia, destruye este objeto
        }
    }

    void Start()
    {
        currentLives = Heart;  // Inicializa las vidas
        gamePaused = false;
    }

    // M�todo para sumar puntos
    public void AddScore(int scoreGive)
    {
        score += scoreGive;
        Debug.Log("Puntos actuales: " + score);
    }

    // Otros m�todos...
}
