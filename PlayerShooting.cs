using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // The projectile prefab to instantiate
    public Transform shootPoint; // The point from where the projectile is shot
    public float fireRate; // Fire rate in seconds

    private float nextFireTime; // Time when the player can shoot next

    void Update()
    {
        // Check if the comma key is pressed and the player can shoot
        if (Input.GetKey(KeyCode.Comma) && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Instantiate a new instance of the projectile prefab at the shoot point position and rotation
        GameObject newProjectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        // Ensure the instantiated projectile has the ProjectileCleanup script
        newProjectile.AddComponent<PlayerShotA>();
    }
}