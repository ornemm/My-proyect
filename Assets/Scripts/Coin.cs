using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 10; 
    public bool final;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Game.obj != null)  //We verify that Game.obj is not null before using it
            {
                Game.obj.AddScore(scoreValue);  //We call the AddScore method of Game
                Debug.Log("Moneda recogida. Puntos sumados: " + scoreValue);
                if (final)
                {
                    Game.obj.Win();
                }
            }
            Destroy(gameObject); //We destroy the coin after it is collected
        }
    }
}