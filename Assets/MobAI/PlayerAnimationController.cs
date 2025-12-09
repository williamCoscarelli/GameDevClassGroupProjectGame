using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator animator;
    public FBIAgentPlayer player;

    public GameObject jumpEffectPrefab;
    public float jumpEffectYOffset = -0.5f;

    private void Reset()
    {
        if (animator == null) animator = GetComponent<Animator>();
        if (player == null) player = GetComponent<FBIAgentPlayer>();
    }

    private void Start()
    {
        if (player == null) player = GetComponent<FBIAgentPlayer>();
        if (animator == null) animator = GetComponent<Animator>();
    }

    // Called every frame from InputForPlayer with whether we're moving or not
    public void SetRunning(bool isRunning)
    {
        animator.SetBool("isRunning", isRunning);
        UpdateIdle();
    }

    // Called once when Space is pressed
    public void OnJumpPressed()
    {
        animator.SetBool("isJumping", true);
        animator.SetBool("isRunning", false);
        animator.SetBool("isIdle", false);

        PlayJumpEffect();
    }
    public void EndJump()
    {
        animator.SetBool("isJumping", false);
        UpdateIdle();
    }

    private void UpdateIdle()
    {
        bool isRunning = animator.GetBool("isRunning");
        bool isJumping = animator.GetBool("isJumping");

        bool isIdle = !isRunning && !isJumping;
        animator.SetBool("isIdle", isIdle);
    }

    private void PlayJumpEffect()
    {
        if (jumpEffectPrefab == null || player == null) return;

        Vector3 spawnPos = player.transform.position +
                           new Vector3(0f, jumpEffectYOffset, 0f);

        GameObject effect = Instantiate(jumpEffectPrefab, spawnPos, Quaternion.identity);
        
        Destroy(effect, 2f);
    }

}