using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnOnCollision : MonoBehaviour
{
    public Transform spawnPoint; // Assign this in the inspector

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = spawnPoint.position;
        }
    }
}

