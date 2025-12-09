using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    public int enemyDamage = 1;
    public Transform attackPoint;
    public float weaponRange;
    public LayerMask playerLayer;

    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer);

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("FBIPlayer"))
            {
                Debug.Log("attacked player");

                // Flash red
                PlayerDamageFlash flash = hit.GetComponent<PlayerDamageFlash>();
                if (flash != null) flash.FlashRed(0.2f);

                // Knockback the player
                Player_Knockback kb = hit.GetComponent<Player_Knockback>();
                if (kb != null)
                {
                    Vector2 direction = (hit.transform.position - transform.position).normalized;
                    kb.Knockback(direction, 10f);
                }

                break;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, weaponRange);
    }
}

