using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 10; // Puntos que se suman al recoger la moneda
    public bool final;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verificamos que Game.obj no sea null antes de usarlo
            if (Game.obj != null)
            {
                Game.obj.AddScore(scoreValue);  // Llamamos al m�todo AddScore de Game
                Debug.Log("Moneda recogida. Puntos sumados: " + scoreValue);
                if (final)
                {
                    Game.obj.Win();
                }
            }
            Destroy(gameObject); // Destruimos la moneda despu�s de que sea recogida
        }
    }
}