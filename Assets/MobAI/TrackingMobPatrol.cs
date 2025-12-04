using UnityEngine;

public class TrackingMobPatrol : MonoBehaviour
{
    private Transform player;      // Reference to player transform
    public float speed = 3f;      // How fast enemy moves

    private bool playerInRange = false;

    private void Update()
    {
        if (playerInRange && player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            playerInRange = true;
            Debug.Log("Player entered enemy range!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player left enemy range!");
        }
    }
}