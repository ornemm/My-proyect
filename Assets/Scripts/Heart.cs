using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public int lifeAmount = 1;  // Cuántas vidas da este item al jugador

    // Método para aumentar las vidas del jugador
    public void GainLife()
    {
        // Verificamos si Game.obj está correctamente asignado
        if (Game.obj != null)
        {
            Game.obj.currentLives += lifeAmount;  // Aumenta las vidas del jugador
            Debug.Log("Vidas actuales: " + Game.obj.currentLives);
        }
        else
        {
            Debug.LogError("Game.obj no está asignado correctamente.");
        }

        // Destruimos el objeto (el item de vida) después de que se recoge
        Destroy(gameObject);
    }
}
