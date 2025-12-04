using UnityEngine;

public class BombDamage : MonoBehaviour
{
    private void Start()
    {
        Collider2D bombCol = GetComponent<Collider2D>();
        if (bombCol == null) return;

        // Find all enemies and ignore collision with them
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Collider2D enemyCol = enemy.GetComponent<Collider2D>();
            if (enemyCol != null)
            {
                Physics2D.IgnoreCollision(bombCol, enemyCol);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Bomb hit player!");
            Destroy(gameObject);
            PlayerDamageFlash playerFlash = collision.gameObject.GetComponent<PlayerDamageFlash>();
            if (playerFlash != null)
            {
                playerFlash.FlashRed(0.2f);
            }
        }
    }
}