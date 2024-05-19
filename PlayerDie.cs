using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public bool isInvincible = false;
    public float invulnDuration = 4.0f;
    public float blinkDuration = 0.1f;
    private Collider2D playerCollider;
    private SpriteRenderer spriteRenderer;
    public Vector2 endPos;
    public Vector2 startingPosition;

    void Start()
    {
        // Initialize the playerCollider and spriteRenderer
        playerCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Check if the components are found
        if (playerCollider == null)
        {
            Debug.LogError("No Collider2D found on the player.");
        }

        if (spriteRenderer == null)
        {
            Debug.LogError("No SpriteRenderer found on the player.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GetComponent<LifeBombManagement>().TakeDamage(1);
            if (!isInvincible)
            {
                StartCoroutine(Invuln());
                StartCoroutine(MoveToPosition(endPos, 1));
            }
        }
    }

    void Update()
    {
        // Update logic here if needed
    }

    IEnumerator Invuln()
    {
        isInvincible = true;
        playerCollider.enabled = false;

        float elapsedTime = 0f;

        bool firstTime = true;

        while (elapsedTime < invulnDuration)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(blinkDuration);
            elapsedTime += blinkDuration;
            if(elapsedTime < invulnDuration / 2 && firstTime)
            {
                blinkDuration = blinkDuration/2;
                firstTime = false;
            }
        }

        // Ensure the sprite is enabled at the end
        spriteRenderer.enabled = true;
        blinkDuration = blinkDuration*2;
        playerCollider.enabled = true;
        isInvincible = false;
    }

        IEnumerator MoveToPosition(Vector2 targetPosition, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector2.Lerp(startingPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the player reaches the target position
        transform.position = targetPosition;
    }
}

