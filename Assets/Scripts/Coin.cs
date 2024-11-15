using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 10; // Puntos que se suman al recoger la moneda

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verificamos que Game.obj no sea null antes de usarlo
            if (Game.obj != null)
            {
                Game.obj.AddScore(scoreValue);  // Llamamos al método AddScore de Game
                Debug.Log("Moneda recogida. Puntos sumados: " + scoreValue);
            }
            Destroy(gameObject); // Destruimos la moneda después de que sea recogida
        }
    }
}