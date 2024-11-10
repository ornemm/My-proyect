using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int points = 10;  // Puntos que se suman al recoger la moneda

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Verificamos que Game.obj no sea null antes de usarlo
            if (Game.obj != null)
            {
                Game.obj.AddScore(points);  // Llamamos al método AddScore de Game
            }
            else
            {
                Debug.LogError("Game.obj no está asignado correctamente.");
            }

            // Destruimos la moneda después de que sea recogida
            Destroy(gameObject);
        }
    }
}
