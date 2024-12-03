using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWalls : MonoBehaviour
{
    public bool playerColliding = false; // Indica si el jugador está dentro del trigger

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entra al trigger tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            playerColliding = true;
            Debug.Log("El jugador ha entrado en el trigger de la pared.");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Verifica si el objeto que sale del trigger tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            playerColliding = false;
            Debug.Log("El jugador ha salido del trigger de la pared.");
        }
    }
}



