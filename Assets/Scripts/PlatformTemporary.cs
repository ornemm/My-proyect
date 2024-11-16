using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTemporary : MonoBehaviour
{
    public float time;
    public float respawnTime;
    public GameObject platformPrefab; // Platform prefab

    private bool hasTouchedPlatform = false; 

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" && !hasTouchedPlatform)
        {
            Debug.Log("Player colisionó con la plataforma. Plataforma destruida en: " + time + " segundos.");
            hasTouchedPlatform = true; //Mark as having touched the platform
            RespawnManager.Instance.StartRespawn(transform.position, respawnTime); //Start respawn
            Destroy(gameObject, time); //Destroy the platform after the specified time
        }
    }
}






