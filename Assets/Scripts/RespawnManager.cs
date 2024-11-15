using System.Collections;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager Instance;
    public GameObject prefab;

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

    public void StartRespawn( Vector3 position, float delay)
    {
        Debug.Log(prefab);

        if (prefab != null)
        {
            StartCoroutine(Respawn(position, delay));
        }
        else
        {
            Debug.LogWarning("Prefab es null. Asegúrate de asignarlo en el inspector.");
        }
    }

    private IEnumerator Respawn(Vector3 position, float delay)
    {
        Debug.Log(prefab);
        yield return new WaitForSeconds(delay);

        if (prefab != null)
        {
            Instantiate(prefab, position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Prefab es null. No se puede instanciar un objeto null.");
        }
    }
}




