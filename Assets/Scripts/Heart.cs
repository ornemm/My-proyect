using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public int lifeAmount = 1;  // Cu�ntas vidas da este item al jugador

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Game.obj != null)
            {
                Game.obj.GainLife(); // Aumenta la vida
                Debug.Log("Coraz�n recogido. Vida aumentada.");
            }
            Destroy(gameObject); // Destruye el item de vida
        }
    }
}