using UnityEngine;

public class ReaperEnemyCombat : MonoBehaviour
{
    private Rigidbody2D rb;
    private int facingDirection = 1; // 1 = facing right, -1 = facing left
    private Animator animator;
    private Transform player;

    public float playerDetectRange;
    public Transform detectionPoint;
    public LayerMask playerLayer;
    public float attackCooldown = 2;
    public float attackCooldownTimer = 2;
    public float attackRange = 2;
    public float speed;
    private EnemyState enemyState;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
    }
    void Update()
    {
        if (enemyState != EnemyState.Knockback)
        {
            CheckForPlayer();
            if (attackCooldownTimer > 0)
            {
                attackCooldownTimer  -= Time.deltaTime;
            }
            if (enemyState == EnemyState.Chasing)
            {
                Chase();
            }
            else if (enemyState == EnemyState.Attacking)
            {
                rb.linearVelocity = Vector2.zero;
            
            }
        }
    }

    void Chase()
    {
        if (player == null) return;

        // Flip to face player if needed
        if ((player.position.x > transform.position.x && facingDirection < 0) ||
            (player.position.x < transform.position.x && facingDirection > 0))
        {
            Flip();
        }

        float dist = Vector2.Distance(transform.position, player.position);

        // Stop moving if close enough (so we don't shove into the player)
        if (dist <= attackRange)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }

    void Flip()
    {
        facingDirection *= -1;

        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * facingDirection;  // ensures exact + / - scale
        transform.localScale = scale;
    }
    private void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectRange, playerLayer);
        if (hits.Length > 0)
        {
            player = hits[0].transform;

            if (Vector2.Distance(transform.position, player.position) <= attackRange && attackCooldownTimer <= 0)
            {
                attackCooldownTimer = attackCooldown;
                ChangeState(EnemyState.Attacking);
            }
            else if (Vector2.Distance(transform.position, player.position) > attackRange && enemyState != EnemyState.Attacking)
            {
                ChangeState(EnemyState.Chasing);
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }
    }

    public void ChangeState(EnemyState newState)
    {
        
        if(enemyState == EnemyState.Idle)
            animator.SetBool("isIdle", false);
        else if (enemyState == EnemyState.Chasing)
            animator.SetBool("isChasing", false);
        else if (enemyState == EnemyState.Attacking)
            animator.SetBool("isAttacking", false);
        
        enemyState = newState;
        
        if(enemyState == EnemyState.Idle)
            animator.SetBool("isIdle", true);
        else if (enemyState == EnemyState.Chasing)
            animator.SetBool("isChasing", true);
        else if (enemyState == EnemyState.Attacking)
            animator.SetBool("isAttacking", true);
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionPoint.position, playerDetectRange);
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("FBIPlayer"))
        {
            // While overlapping the player, don't move into them
            rb.linearVelocity = Vector2.zero;
        }
    }
}

public enum EnemyState
{
    Idle,
    Chasing,
    Attacking,
    Knockback
}
