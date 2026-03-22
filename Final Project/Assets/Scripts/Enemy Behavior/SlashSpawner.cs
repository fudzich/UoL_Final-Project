using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashSpawner : MonoBehaviour
{
    [SerializeField] private GameObject slashPrefab;
    [SerializeField] private string projectileTag;

    // Method to spawn projectile from the front of the object
    public void SpawnSlash()
    {
        if (slashPrefab == null)
        {
            Debug.LogWarning("Slash Prefab is not assigned.");
            return;
        }

        // Instantiate the projectile at the front of the object
        Vector3 spawnPosition = transform.position + transform.forward * 1f;
        GameObject projectile = Instantiate(slashPrefab, spawnPosition, transform.rotation);

        // Assign the tag to the projectile
        projectile.tag = projectileTag;
    }
}
