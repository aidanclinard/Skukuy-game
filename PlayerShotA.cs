using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotA : MonoBehaviour
{
    private Camera mainCamera;
    private Vector2 screenBounds;
    public float speed = 30f; // Speed at which the projectile moves upwards

    void Start()
    {
        // Get the main camera
        mainCamera = Camera.main;

        // Calculate screen bounds with 50% leniency
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        screenBounds *= 1.5f;
    }

    void Update()
    {
        // Move the projectile upwards
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // Check if the projectile is outside the screen bounds with leniency
        if (transform.position.y > screenBounds.y || transform.position.y < -screenBounds.y)
        {
            Destroy(gameObject);
        }
    }
}

