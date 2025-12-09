using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FBIPlayer"))
        {
            Debug.Log("Enemy attacked the Player!");
            Destroy(gameObject);
            PlayerDamageFlash playerFlash = collision.gameObject.GetComponent<PlayerDamageFlash>();
            if (playerFlash != null)
            {
                playerFlash.FlashRed(0.2f);
            }
        }
    }
}
