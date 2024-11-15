using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTemporary : MonoBehaviour
{
    public float time;
    public float respawnTime;
    public GameObject platformPrefab; // Prefab de la plataforma

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("Player colisionó con la plataforma. Plataforma destruida en: " + time + " segundos.");
            Destroy(gameObject, time);
            RespawnManager.Instance.StartRespawn(platformPrefab, transform.position, respawnTime); // Iniciar el respawn
        }
    }
}




