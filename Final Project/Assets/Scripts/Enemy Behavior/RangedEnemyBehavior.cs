using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyBehavior : MonoBehaviour
{
    [SerializeField] private float focusDistance = 10f; // Max distance to target player
    [SerializeField] private List<string> targetTags; // Tags of all elements
    [SerializeField] private float fireRate = 1f; // Time between attacks
    private float fireTimer = 0f;
    private ProjectileSpawner projectileSpawner;
    private HealthManagement health;

    void Start()
    {
        projectileSpawner = GetComponent<ProjectileSpawner>();
        if (projectileSpawner == null)
        {
            Debug.LogError("ProjectileSpawner component not found on the Enemy.");
        }

        health = GetComponent<HealthManagement>();
        if (health == null)
        {
            Debug.LogError("HealthManagement component not found on this GameObject.");
        }

        string objTag = gameObject.tag; // Get the tag of the object
        // Check if the tag exists in the list
        if (targetTags.Contains(objTag))
        {
            // Remove the tag of the object from the target list
            targetTags.Remove(objTag);
        }

    }

    void Update()
    {
        if (PlayerInfo.gameStart)
        {
            // Update the cooldown timer
            fireTimer += Time.deltaTime;

            GameObject target = null;
            float closestDistance = Mathf.Infinity;

            // Find the Player first
            GameObject player = GameObject.Find("Player");
            if (player != null)
            {
                float distToPlayer = Vector3.Distance(transform.position, player.transform.position);
                if (distToPlayer <= focusDistance)
                {
                    // Check if player's tag is in the list
                    if (targetTags.Contains(player.tag))
                    {
                        target = player;
                        closestDistance = distToPlayer;
                    }
                }
            }

            // If player not prioritized, check other objects
            if (target == null)
            {
                foreach (string tag in targetTags)
                {
                    GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
                    foreach (GameObject obj in objects)
                    {
                        // Ignore attacks"
                        if (obj.name == "Bullet(Clone)")
                            continue;
                        if (obj.name == "Slash(Clone)")
                            continue;
                        
                        // Find the closest target
                        float dist = Vector3.Distance(transform.position, obj.transform.position);
                        if (dist <= focusDistance && dist < closestDistance)
                        {
                            target = obj;
                            closestDistance = dist;
                        }
                    }
                }
            }

            // If a target is found, turn towards it and spawn projectile
            if (target != null)
            {
                Vector3 direction = (target.transform.position - transform.position).normalized;
                direction.y = 0f;
                // Rotate to face the target
                if (direction != Vector3.zero)
                {
                    Quaternion lookRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 15f);
                }

                // Check if cooldown has passed before firing
                if (fireTimer >= fireRate)
                {
                    if (projectileSpawner != null)
                    {
                        projectileSpawner.SpawnProjectile(gameObject.tag);
                    }
                    fireTimer = 0f; // reset timer after firing
                }
            }
        }
        
    }

    private void moveToclosest(GameObject closestOutsideTarget)
    {
        Vector3 direction = (closestOutsideTarget.transform.position - transform.position).normalized;
        direction.y = 0f;

        // Move towards the target
        float moveSpeed = 3f; // or define as a serialized field
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Optional: rotate to face the target
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 15f);
        }
    }

}
