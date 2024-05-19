using UnityEngine;
using UnityEngine.UI;

public class LifeBombManagement : MonoBehaviour
{
    public Image[] lives; // Array of UI Images representing the lives
    public int life; // Current life count
    public Sprite emptyLifeSprite; // Sprite representing an empty life
    public Sprite fullLifeSprite; // Sprite representing a full life
    private int maxLives; // Maximum number of lives

    void Start()
    {
        // Ensure all references are assigned correctly
        if (lives == null || lives.Length == 0)
        {
            Debug.LogError("Lives array is not assigned or empty.");
            return;
        }
        if (emptyLifeSprite == null)
        {
            Debug.LogError("Empty life sprite is not assigned.");
            return;
        }
        if (fullLifeSprite == null)
        {
            Debug.LogError("Full life sprite is not assigned.");
            return;
        }

        maxLives = lives.Length; // Initialize maxLives to the length of the lives array
        UpdateLifeSprites(); // Initial update to ensure UI is correct at start
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        life = Mathf.Clamp(life, 0, maxLives); // Ensure life does not go below 0 or above maxLives
        UpdateLifeSprites(); // Update UI after taking damage
    }

    void UpdateLifeSprites()
    {
        if (lives == null || lives.Length == 0)
        {
            Debug.LogError("Lives array is not assigned or empty.");
            return;
        }
        if (emptyLifeSprite == null || fullLifeSprite == null)
        {
            Debug.LogError("Life sprites are not assigned.");
            return;
        }

        for (int i = 0; i < maxLives; i++)
        {
            if (i < life)
            {
                if (lives[i] != null)
                {
                    lives[i].sprite = fullLifeSprite;
                }
                else
                {
                    Debug.LogError($"Life image at index {i} is not assigned.");
                }
            }
            else
            {
                if (lives[i] != null)
                {
                    lives[i].sprite = emptyLifeSprite;
                }
                else
                {
                    Debug.LogError($"Life image at index {i} is not assigned.");
                }
            }
        }

        if (life <= 0)
        {
            Debug.Log("Game Over");
            // Additional game over logic can be added here
        }
    }
}
