using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //We verify that the collided object has the "Player" tag
        {
            if (Game.obj != null) //Verify that the Game.obj instance is not null before calling the GameOver() method
            {
                Game.obj.GameOver(); //We call the GameOver() method of Game
                Debug.Log("Jugador ha muerto. Game Over.");
                FindAnyObjectByType<GameOver>().ShowGameOver();
            }
            else
            {
                Debug.LogError("No se ha encontrado la instancia de Game.obj");
            }
        }
    }
}