using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorIsLava : MonoBehaviour
{
    [SerializeField] private float fireDamage = 2f;
    private float damageTimer = 0f;

    private void OnTriggerStay(Collider other)
    {
        // Check if the object is not Fire
        if (other.gameObject.tag != "Fire")
        {
            // Increment the timer
            damageTimer += Time.deltaTime;

            // Apply damage every 1 second
            if (damageTimer >= 1f)
            {
                // Try to get the HealthManagement component from the player object
                if(other.name == "Player")
                {
                    var health = other.GetComponent<PlayerHealthManagement>();
                    if (health != null)
                    {
                        health.TakeDamage(fireDamage);
                    }
                    damageTimer = 0f;
                }
                // Try to get the HealthManagement component from the other object
                else{
                    var health = other.GetComponent<HealthManagement>();
                    if (health != null)
                    {
                        health.TakeDamage(fireDamage);
                    }
                    damageTimer = 0f;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Fire")
        {
            // Reset timer when player leaves
            damageTimer = 0f;
        }
    }
}
