using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<Player>().SendMessage("Reposition");
    }
}
