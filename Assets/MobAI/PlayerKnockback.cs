using System.Collections;
using UnityEngine;

public class Player_Knockback : MonoBehaviour
{
    public Rigidbody2D rb;
    public float recoveryTime = 0.2f;  // how long the player is stunned

    private bool isKnocked = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Knockback(Vector2 direction, float force)
    {
        if (isKnocked) return;

        isKnocked = true;

        rb.linearVelocity = Vector2.zero;          // reset movement
        rb.AddForce(direction * force, ForceMode2D.Impulse);

        StartCoroutine(Recover());
    }

    private IEnumerator Recover()
    {
        yield return new WaitForSeconds(recoveryTime);
        isKnocked = false;
    }
}

