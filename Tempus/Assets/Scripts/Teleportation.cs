using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public Transform teleportDestination; // Drag and drop the destination object here

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportPlayer(other.gameObject);
        }
    }

    private void TeleportPlayer(GameObject player)
    {
        if (teleportDestination != null)
        {
            player.transform.position = teleportDestination.position;
            Debug.Log("Player teleported to: " + teleportDestination.position);
        }
        else
        {
            Debug.LogError("Teleport destination is not assigned in the Teleportation script.");
        }
    }
}
