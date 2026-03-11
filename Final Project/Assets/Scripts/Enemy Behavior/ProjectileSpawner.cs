using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    // Serialized fields for customization in inspector
    [SerializeField] private GameObject projectilePrefab;
    //[SerializeField] private string projectileTag;
    [SerializeField] private Material projectileMaterial;

    // Method to spawn projectile from the front of the object
    public void SpawnProjectile(string projectileTag)
    {
        if (projectilePrefab == null)
        {
            Debug.LogWarning("Projectile Prefab is not assigned.");
            return;
        }

        // Instantiate the projectile at the front of the object
        // Assuming the front is along the object's forward direction
        Vector3 spawnPosition = transform.position + transform.forward * 1f; // offset in front
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, transform.rotation);

        // Assign the tag to the projectile
        projectile.tag = projectileTag;

        // Apply the material if assigned
        if (projectileMaterial != null)
        {
            Renderer renderer = projectile.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = projectileMaterial;
            }
            else
            {
                Debug.LogWarning("Projectile does not have a Renderer component.");
            }
        }

    }

    
}
