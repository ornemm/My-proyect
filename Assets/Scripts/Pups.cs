using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pups : MonoBehaviour
{
    public int scoreValue = 100; // Puntos que se suman al recoger a la cría

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verificamos que Game.obj no sea null antes de usarlo
            if (Game.obj != null)
            {
                Game.obj.AddScore(scoreValue);  // Llamamos al método AddScore de Game
                Debug.Log("Hijo recogido. Puntos sumados: " + scoreValue);
            }
            Destroy(gameObject); // Destruimos la cría después de que sea recogida
        }
    }
}
