using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform spawnPoint; // Assign your spawn point in the Unity Editor

    void Update()
    {
        // Check if the player falls below a certain Y threshold (e.g., falls off the map)
        if (transform.position.y < -10f) // You can adjust the threshold as needed
        {
            RespawnPlayer();
        }
    }

    void RespawnPlayer()
    {
        // Set the player's position to the spawn point
        transform.position = spawnPoint.position;
        // You may also want to reset the player's rotation, velocity, or any other relevant properties

        // Debug log to indicate respawn (optional)
        Debug.Log("Player respawned at " + spawnPoint.position);
    }
}
