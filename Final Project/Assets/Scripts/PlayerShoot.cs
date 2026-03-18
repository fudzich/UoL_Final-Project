using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private ProjectileSpawner projectileSpawner;

    void Start()
    {
        // Get the ProjectileSpawner component attached to this gameObject
        projectileSpawner = GetComponent<ProjectileSpawner>();
        if (projectileSpawner == null)
        {
            Debug.LogError("ProjectileSpawner component not found on the GameObject.");
        }
    }

    void Update()
    {
        // Check if left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Call the SpawnProjectile method
            if (projectileSpawner != null && PlayerInfo.canCast)
            {
                projectileSpawner.SpawnProjectile(gameObject.tag);
            }
        }
    }
}
