using System.Collections;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartRespawn(GameObject prefab, Vector3 position, float delay)
    {
        StartCoroutine(Respawn(prefab, position, delay));
    }

    private IEnumerator Respawn(GameObject prefab, Vector3 position, float delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(prefab, position, Quaternion.identity);
    }
}


