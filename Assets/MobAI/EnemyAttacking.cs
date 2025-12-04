using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy attacked the Player!");
            Destroy(gameObject);
            PlayerDamageFlash playerFlash = collision.gameObject.GetComponent<PlayerDamageFlash>();
            if (playerFlash != null)
            {
                playerFlash.FlashRed(0.2f); // flash for 0.2 seconds (change to 1f if you want a full second)
            }
        }
    }
}
