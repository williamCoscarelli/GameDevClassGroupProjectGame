using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 3f;

    public GameObject hitEffectPrefab;  

    private Vector2 direction = Vector2.right;

    public void Initialize(Vector2 dir)
    {
        direction = dir.normalized;
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FBIPlayer"))
        {
            Debug.Log("Bullet hit player!");

            PlayerDamageFlash playerFlash = other.GetComponent<PlayerDamageFlash>();
            if (playerFlash != null)
            {
                playerFlash.FlashRed(0.2f);
            }

            SpawnHitEffect();
            Destroy(gameObject);
            return;
        }

        if (other.CompareTag("Ground") || other.CompareTag("Platform"))
        {
            SpawnHitEffect();
            Destroy(gameObject);
        }
    }

    private void SpawnHitEffect()
    {
        if (hitEffectPrefab != null)
        {
            GameObject fx = Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);

            ParticleSystem ps = fx.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                Destroy(fx, ps.main.duration + ps.main.startLifetime.constantMax);
            }
            else
            {
                Destroy(fx, 2f);
            }
        }
    }
}