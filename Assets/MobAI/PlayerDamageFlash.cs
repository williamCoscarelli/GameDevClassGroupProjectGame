using System.Collections;
using UnityEngine;

public class PlayerDamageFlash : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void FlashRed(float duration = 0.2f)
    {
        StartCoroutine(FlashingRed(duration));
    }

    private IEnumerator FlashingRed(float duration)
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(duration);
        spriteRenderer.color = originalColor;
    }
}

