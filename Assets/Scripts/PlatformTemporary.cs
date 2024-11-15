using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTemporary : MonoBehaviour
{
    public float time;
    public float respawnTime;
    public GameObject platformPrefab; // Prefab de la plataforma

    private bool hasTouchedPlatform = false; // Nueva variable para controlar el toque en la plataforma

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" && !hasTouchedPlatform)
        {
            Debug.Log("Player colisionó con la plataforma. Plataforma destruida en: " + time + " segundos.");
            hasTouchedPlatform = true; // Marcar como que ha tocado la plataforma
            RespawnManager.Instance.StartRespawn(transform.position, respawnTime); // Iniciar el respawn
            Destroy(gameObject, time); // Destruir la plataforma después del tiempo especificado
        }
    }
}






