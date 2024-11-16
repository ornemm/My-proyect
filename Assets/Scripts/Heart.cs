using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public int lifeAmount = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Game.obj != null)
            {
                Game.obj.GainLife(); //Increases life
                Debug.Log("Corazón recogido. Vida aumentada.");
            }
            Destroy(gameObject); //Destroy the health item
        }
    }
}