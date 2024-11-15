using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificamos que el objeto colisionado tiene el tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verificamos que la instancia de Game.obj no sea null antes de llamar al método GameOver()
            if (Game.obj != null)
            {
                Game.obj.GameOver(); // Llamamos al método GameOver() de Game
                Debug.Log("Jugador ha muerto. Game Over.");
            }
            else
            {
                Debug.LogError("No se ha encontrado la instancia de Game.obj");
            }
        }
    }
}