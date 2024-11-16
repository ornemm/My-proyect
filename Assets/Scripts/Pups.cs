using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pups : MonoBehaviour
{
    public int scoreValue = 100; 

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //We verify that Game.obj is not null before using it
            if (Game.obj != null)
            {
                Game.obj.AddScore(scoreValue); //We call the AddScore method of Game
                Debug.Log("Hijo recogido. Puntos sumados: " + scoreValue);
            }
            Destroy(gameObject); //We destroy the brood after it is collected
        }
    }
}
