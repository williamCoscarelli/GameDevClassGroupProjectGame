using UnityEngine;

public class NonTrackingMobPatrol : MonoBehaviour
{
    public float moveDistance;
    public float speed;
    public GameObject bulletPrefab;
    public float shootInterval = 1f;
    public float bulletSpeed = 5f;
    public Transform shootPoint;   // ← new shoot transform!

    private Animator animator;
    private Vector3 startPos;
    private Vector3 endPos;
    private bool goingRight = true;
    private float shootTimer = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        setStartAndEndPosition();
    }

    private void setStartAndEndPosition()
    {
        startPos = transform.position;
        endPos = startPos + Vector3.right * moveDistance;
    }

    void Update()
    {
        if (animator != null)
            animator.SetBool("isWalking", true);

        // Movement
        Vector3 target = goingRight ? endPos : startPos;

        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            goingRight = !goingRight;

            // flip sprite
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        // Shooting logic
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    private void Shoot()
    {
        if (bulletPrefab == null || shootPoint == null) return;

        // Determine shooting direction based on scale.x
        float facing = Mathf.Sign(transform.localScale.x); // +1 right, -1 left
        Vector2 dir = (facing > 0) ? Vector2.right : Vector2.left;

        // Spawn bullet at ShootPoint
        GameObject bullet = Instantiate(
            bulletPrefab,
            shootPoint.position,
            Quaternion.identity
        );

        // Assign direction to bullet script
        EnemyBullet bulletScript = bullet.GetComponent<EnemyBullet>();
        if (bulletScript != null)
        {
            bulletScript.Initialize(dir);
            bulletScript.speed = bulletSpeed;
        }
    }
}
