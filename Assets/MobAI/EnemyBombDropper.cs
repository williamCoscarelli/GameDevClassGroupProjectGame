using UnityEngine;

public class EnemyBombDropper : MonoBehaviour
{
    public GameObject bombParticlesPrefab;
    public GameObject bombPrefab;
    public float dropInterval = 3f;
    public float bombLifetime = 3f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= dropInterval)
        {
            DropBomb();
            timer = 0f;
        }
    }

    private void DropBomb()
    {
        GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
        if (bombParticlesPrefab != null)
        {
            GameObject fx = Instantiate(bombParticlesPrefab, bomb.transform.position, Quaternion.identity);
            fx.transform.SetParent(bomb.transform); // stick to bomb
        }
        
        Collider2D enemyCol = gameObject.GetComponent<Collider2D>();
        Collider2D bombCol = bomb.GetComponent<Collider2D>();       

        if (enemyCol != null && bombCol != null)
        {
            Physics2D.IgnoreCollision(bombCol, enemyCol);
        }
        Destroy(bomb, bombLifetime);
    }
}