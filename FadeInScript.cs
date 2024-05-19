using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component
    public float fadeDuration = 2f; // Duration of the fade-in effect in seconds

    void Start()
    {
        // Ensure we have a reference to the SpriteRenderer component
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Start the fade-in effect
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float currentAlpha = 1f; // Start with full alpha (1)

        // Loop until the alpha value is zero
        while (currentAlpha > 0f)
        {
            // Calculate the new alpha value based on time and duration
            currentAlpha -= Time.deltaTime / fadeDuration;

            // Clamp the alpha value to make sure it doesn't go below zero
            currentAlpha = Mathf.Clamp01(currentAlpha);

            // Update the sprite's alpha value
            Color newColor = spriteRenderer.color;
            newColor.a = currentAlpha;
            spriteRenderer.color = newColor;

            // Wait for the next frame
            yield return null;
        }

        // Optionally disable the GameObject or perform other actions after fade-in completes
        Debug.Log("Fade-in complete!");
    }
}
