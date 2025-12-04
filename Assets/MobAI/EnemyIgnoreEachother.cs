using UnityEngine;

public class EnemyIgnoreEachOther : MonoBehaviour
{
    void Start()
    {
        Collider2D myCol = GetComponent<Collider2D>();
        if (myCol == null) return;

        // Find all enemies in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            // Don't compare with self
            if (enemy == gameObject) 
                continue;

            Collider2D enemyCol = enemy.GetComponent<Collider2D>();
            if (enemyCol != null)
            {
                Physics2D.IgnoreCollision(myCol, enemyCol);
            }
        }
    }
}